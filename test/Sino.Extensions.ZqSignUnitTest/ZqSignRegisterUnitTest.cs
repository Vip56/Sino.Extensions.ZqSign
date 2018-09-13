using Sino.Extensions.ZqSign;
using Sino.Extensions.ZqSign.Register;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Sino.Extensions.ZqSignUnitTest
{
    public class ZqSignRegisterUnitTest
    {
        IZqSignService Service { get; set; }

        public ZqSignRegisterUnitTest()
        {
            ZqSignConfiguration config = new ZqSignConfiguration
            {
                PrivateKey = "",
                AppId = "ZQABA206A379B342FB987B8DCCBA679549",
                Url = "http://test.sign.zqsign.com:8081/"
            };
            Service = new ZqSignService(config);
        }

        [Fact]
        public async Task RegisterPersonExistedTest()
        {
            var request = new RegisterPersonRequest
            {
                UserCode = "2018091316200001",
                Name = "无厘头",
                Mobile = "15011111111",
                IdCardNo = "321111198602212564"
            };
            var response = await Service.RegisterPersonAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.UserCodeExisted, response.Code);
        }

        [Fact]
        public async Task RegisterPersonTest()
        {
            var request = new RegisterPersonRequest
            {
                UserCode = DateTime.Now.ToFileTimeUtc().ToString(),
                Name = "无厘头",
                Mobile = "15011111111",
                IdCardNo = "321111198602212564"
            };
            var response = await Service.RegisterPersonAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task RegisterEnterpriseTest()
        {
            var request = new RegisterEnterpriseRequest
            {
                UserCode = DateTime.Now.ToFileTimeUtc().ToString(),
                Name = "浙江淘宝网络有限公司",
                Certificate = "913301107517434382",
                Address = "浙江省杭州市西湖区文二路391号",
                Contact = "张勇",
                Mobile = "15858645685"
            };
            var response = await Service.RegisterEnterpriseAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task RegisterEnterpriseExistedTest()
        {
            var request = new RegisterEnterpriseRequest
            {
                UserCode = "2018091316200002",
                Name = "浙江淘宝网络有限公司",
                Certificate = "913301107517434382",
                Address = "浙江省杭州市西湖区文二路391号",
                Contact = "张勇",
                Mobile = "15858645685"
            };
            var response = await Service.RegisterEnterpriseAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.UserCodeExisted, response.Code);
        }

        [Fact]
        public async Task UpdatePersonTest()
        {
            var request = new UpdatePersonRequest
            {
                UserCode = "2018091316200001",
                Name = "刺猬头",
                Mobile = "15867865485",
                IdCardNo = "321111198602212564"
            };
            var response = await Service.UpdatePersonAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task UpdatePersonNotExistedTest()
        {
            var request = new UpdatePersonRequest
            {
                UserCode = DateTime.Now.ToFileTimeUtc().ToString(),
                Name = "刺猬头",
                Mobile = "15867865485",
                IdCardNo = "321111198602212564"
            };
            var response = await Service.UpdatePersonAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.UserCodeNotExisted, response.Code);
        }

        [Fact]
        public async Task UpdateEnterpriseTest()
        {
            var request = new UpdateEnterpriseRequest
            {
                UserCode = "2018091316200002",
                Name = "浙江淘宝网络有限公司",
                Certificate = "913301107517434382",
                Address = "浙江省杭州市西湖区文二路391号",
                Contact = "张勇",
                Mobile = "15858645685"
            };
            var response = await Service.UpdateEnterpriseAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task UpdateEnterpriseNotExistedTest()
        {
            var request = new UpdateEnterpriseRequest
            {
                UserCode = DateTime.Now.ToFileTimeUtc().ToString(),
                Name = "浙江淘宝网络有限公司",
                Certificate = "913301107517434382",
                Address = "浙江省杭州市西湖区文二路391号",
                Contact = "张勇",
                Mobile = "15858645685"
            };
            var response = await Service.UpdateEnterpriseAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.UserCodeNotExisted, response.Code);
        }

        [Fact]
        public async Task ChangeSignatureTest()
        {
            var imagePath = Path.Combine(AppContext.BaseDirectory, "SignatureImage.png");
            var imageBytes = File.ReadAllBytes(imagePath);
            var imageBase64 = Convert.ToBase64String(imageBytes);

            var request = new ChangeSignatureRequest
            {
                UserCode = "2018091316200001",
                SignatureImage = imageBase64
            };
            var response = await Service.ChangeSignatureAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }
    }
}
