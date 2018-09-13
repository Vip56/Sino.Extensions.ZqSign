using Sino.Extensions.ZqSign;
using Sino.Extensions.ZqSign.Contract;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Sino.Extensions.ZqSignUnitTest
{
    public class ZqSignContractUnitTest
    {
        IZqSignService Service { get; set; }

        public ZqSignContractUnitTest()
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
        public async Task CreateContractTest()
        {
            var request = new CreateContractRequest
            {
                TemplateId = "bf4a24f22da44afaba254918febd7ce9",
                ContractId = DateTime.Now.ToFileTimeUtc().ToString(),
                ContractVal = "{'jsonVal':[{'测试':'','2':'','3':'','4':'','5':'','6':'','7':'','8':'','9':'','10':'','Signer1':'2018091316200001','Signer2':'2018091316200002','承租方':'张三','12':'','13':'','14':'','15':'','16':'','17':'','出租方':'李四','18':'','19':'','20':''}]}",
                Name = "合同"
            };
            var response = await Service.CreateContractAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task CreateContractWithNotExistedTemplateIdTest()
        {
            var request = new CreateContractRequest
            {
                TemplateId = "test",
                ContractId = "201809131828",
                ContractVal = "{'jsonVal':[{'测试':'','2':'','3':'','4':'','5':'','6':'','7':'','8':'','9':'','10':'','Signer1':'2018091316200001','Signer2':'2018091316200002','承租方':'张三','12':'','13':'','14':'','15':'','16':'','17':'','出租方':'李四','18':'','19':'','20':''}]}",
                Name = "合同"
            };
            var response = await Service.CreateContractAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.TemplateIdNotExisted, response.Code);
        }

        [Fact]
        public async Task CreateContractWithExistedContractIdTest()
        {
            var request = new CreateContractRequest
            {
                TemplateId = "bf4a24f22da44afaba254918febd7ce9",
                ContractId = "201809131827",
                ContractVal = "{'jsonVal':[{'测试':'','2':'','3':'','4':'','5':'','6':'','7':'','8':'','9':'','10':'','Signer1':'2018091316200001','Signer2':'2018091316200002','承租方':'张三','12':'','13':'','14':'','15':'','16':'','17':'','出租方':'李四','18':'','19':'','20':''}]}",
                Name = "合同"
            };
            var response = await Service.CreateContractAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.ContractIdExisted, response.Code);
        }

        [Fact]
        public async Task AutoSignContractTest()
        {
            var request = new AutoSignRequest
            {
                ContractId = "201809131827",
                Signers = "2018091316200001"
            };
            var response = await Service.AutoSignAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task GetContractImageTest()
        {
            var request = new GetContractImgRequest
            {
                ContractId = "201809131827"
            };

            var response = await Service.GetContractImgAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task GetContractPdfTest()
        {
            var request = new GetContractPdfRequest
            {
                ContractId = "201809131827"
            };
            var response = await Service.GetContractPdfAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task GetSignViewTest()
        {
            var request = new GetSignViewRequest
            {
                ContractId = "201809131827",
                UserCode = "2018091316200002",
                SignType = SignType.WRITTEN,
                NotifyUrl = "http://ecs.sowl.cn/ecscb/EContract/H5SignNotify/201809131827",
                ReturnUrl = "http://ecs.sowl.cn/ecscb/"
            };
            var response = await Service.GetSignViewAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task GetAppShowTest()
        {
            var request = new GetAppShowRequest
            {
                UserCode = "2018091316200001",
                ContractId = "201809131827"
            };
            var response = await Service.GetAppShowAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task AppSignContractTest()
        {
            var request = new AppSignContractRequest
            {
                UserCode = "2018091316200001",
                ContractId = "201809131827",
                PageNumber = "0",
                ImageWidth = "100",
                ImageHeight = "100",
                MobileHeight = "667",
                MobileWidth = "375",
                X = "0.573809",
                Y = "0.4046703",
                ImageBase64 = string.Format(@"iVBORw0KGgoAAAANSUhEUgAAAKUAAACmCAYAAAC7v090AAAAAXNSR0IArs4c6QAAABxpRE9UAAAAAgAAAAAAAABTAAAAKAAAAFMAAABTAAAKxQcNBgUAAAqRSURBVHgB7J3tbhzHDkT9/i+dCwr3KJVif3J6rN3VBAiKTRYP2e2RHcA/8uefP3/+ef593uCVvoE/r7TMs8vzwxHfwPNRPn9SvNyflM9H+XyUr/9R/nn+eV6g+AJff/QWev0/29LvlAXm07LwAjz8gvVtLdxx9+PUvq/elHjbJzmzOO9xhvYvBS76b2UeRc/cteeo7DGbAFN11hN19UecEyuUD/Wkxzl8zypf+06spLyITzCD4VzOMz4+NIFmgE+u8yiuJ+/s7DjP+K2e07nZDiv11k6VvmMfZWuhT8qtPO6qp/Uuo96W/47caIeVmu+00hOe1JcSq6SGz1mfcm5c9VKq9y49qPt7vtW88+K82jvyOXfk1VrqSwl1/7LY3yLOdz3Bziz3Xt3pNI99qtzUlxJM+IXqbxHnu56hNas3z71XdzrNY58qN/WlBBN+ofpbxPnOZ1id576rO53msU+Vm/pSggm/UP0t4nznM/i83qxVX6/f86d58Kvc1JcSTPiF6m8R5zufwef1Zq36ev2e3+HhdUbrjBdteVo5/Gi8+n/+Qr7V9Fty/hZxvvvuzBzNwYOOvCsOOioBw96yqsc2OjzUcrr8CiqUv6xUPeJ+OoiOzz3cm7tQA1teVo5/OjzUcor8SiqUv6xUPeJ+OoiOzz3cm7tQA1teVo5/OjzUcor8SiqUv6xUPeJuLcIvl6dPD6UfEvxqLZ8kVNPxD2f51NfSnjHG5+52+oV8Kuu9t7p030i7s067Ys5q8xdr94hzUgJdb9xXLmX98R59wlg7PaN/DDRnpe6q/tndfXf5R3O2BmqoFeO/U6cZzvjU531tOr0t2qVHDy0x6Du6v5ZXf13eYczdoYq6FVjv4+fR3u7N84jf6/mnJ5vNb/Kc1+cWzPc1/KQu8sLPzTNSAl1N2L3v+O5ca2vVOsuPe8s76yZ3+vRT26VddoX81eZu17u1uzbGQrIe97xzF1UW/fQ+m7svNV++vBzRsm7Uke9zpk6Sr6leNCWhxwelPxM8aNbPwkz+LvXeRTVK3dSDvEKz72c0R6DOnrVF/2w0B5z16sc2OjWUAV9YsyjqF69p7KIZ8zwqYc+VGsaU0e1pjF1VGse40G9rmc8qNZGMX70+SjltXgUVSmXQmVpPIKFT+va57U7fcFenb3rHe69M1RBnxj7W4w+gNX7t5gjLn7lk0O1pjF1VGsaU0e15jEe1Ot6xoNqbRTjR7d+EkbgT6jxKKon7qU84h63VSeHznpP+WIOLLQ3e9erHNjo1lAFfWLMo6ieuKfyiHvcqHuNHtTrnKmj5F2po17XMx5Uax7jQb3eO+NHb/koA95b4HT+5CweRfXUvsrs7YzHZ5JHvc6ZOkrelTrqdT3jQbXmMR7U670zfvS2jzIG9JY4lecSp2Ypj/hv7tqbSR7t7UQdveqLflhoj7nrVQ5sdGuogkYxcHTkrdZgu1Z50eesOF/h7fYy3/vIo17nTB0l70od9bqe8aBa8xgP6vXeGT+afiF6jTt54D+lO7uqt7Wv1u+Mmd2aQQ1teSJHHb3q22HuenU39kWXL6KQWQz8p3S2X6/e2rfnPZ1ndotLDW15IkcdverbYe56dTf2RZcvopBZDFx11lOpKz/iCkN7nHeCqfxRzOyWhxra8kSOOnrVt8Pc9epu7IsuX0Qhsxi46qynUld+xBWG9jjvBFP5vVjntjxaH+102he7rDJ3vXrPNCMl1F2MnRnnImrY5nOG5oWi8+7a21dhruc5U0fJu1JHvc6ZOkq+pXjQloccHpT8TPGjWz8JMzh14KrUTqryI77Kdt4J5spOzO15qaN/yxdzmIn2Zu96lQMb3RqqoFEMXHXkr9aUH3GVQ5/zTjBh91RnrnhGOynrhC/2WWXuevWuaUZKqLsYOzPORdSwzecMzQtF5921t66iMzWvsXpGO6lP+z1W34gXfXd5dac0IyXUXYydGeciatjmc4bmhaLz7tpbV2Gm5jzGg3qdM/VQci1V3095da+0T0qouxg7c3bx4pitn+KVGX9rb3bReeRaqr7eW654YL+Cl11C0z4poe5i7Mw4F1HDNp8zNC8UnXfX3qyi88i1VH29nVY8sF/Byy6haZ+UUHcxdmaci6hhm88ZmheKzrtrb1bReeRaqr7eTise2K/gZZfQtE9KqLsYOzPORdSwzecMzQtF5921d6yis2arqbe304qHOa/gZZfQtE9KqLsYOzPORdSwzecMzQtF5921d6yis2arqbe304qHOa/gZZfQtE9KqLsYOzPORdSwzecMzQtF573K3r5X6yorHvpewcsuoWmflFB3MXZmnIuoYZvPGZoXis67Y+/KDO9pXUU9rbrm1Bux1jy+y6tz0oyUUHcxdmaci6hhm88ZmheKztvd2/t9pNdX+d4343rdz8rzmp/VO9t3x6tzUl9KqLsYO/NvnYvrfre19vwuLgYtxii3gvV+75nVW37P9c477B2vzkt9KaHuYuzMv3Uurvvd1trzu1gIWjzPrWBnPbP6yoyeZ4e949V5qS8l1F2MnRnnImrY5nOG5oWi807t3eKSW1grHu/r/+DR81IP7XmqeWUT91jU0Z7P8/jR7wt/J7yjcIalWsBMW5Qf8bRhYnDeCSYjW+wTfOcy75Q6f7Sze1d3SH0psUoa+JwZ54G9XPI5ZdD/G513em/nX903+nvMU7v3+K3dd7zan/pSQt3F2JlxLqKGbT5naF4oOu/03s5fWGlqGTGpTSEDw84bMA8dYP9Two92f9L+07V5AK66iViyn+Yrj3hpkUUTTHSxrWuDg7qRfKjX7jjrvJ2ZqS8lDmzrzJ0Fd8af5t69t/N37tryrvDU02KczOmsiFfZqS8lVkkDnzIHtpcr6d7EJ5eEiV5hw0BHLDzoyHulBh9dZeFHb/nje3WZV/PxKKond1RuxFfYu6xdf2W36ozUlxKVbT6kx98izqeudpLtrJUdvSfOK307Hp+x2pv6UmKV9IE+f4s4n7rmKbZzdvbz3jjv9M+8zp/5qae+lMD5C9XfIs6nnuEE2xmV3ZwR5wqn1ePslqeVS30p0er6JTl/izifuvoJtjMquzmDc4XlPbBQr/fO+NF49a+/V0V7jb8hzxuonri38jTeYWtfxDu97nXWVR5855KfaepLiRnhTep+Lz37FbSmsfuqZ2VqvMrTnohX+3o+551gxizn9uZ7PvWlhHe86dnvVTmfvHpr/grf+1Z6VjzOjXOrr+VbzbV4rZzzyl93C/6qOb/06vnkfVozZ3ztmXl368qOeNbv/pXzjEndWb/io+Tyof4Ao7P2nYh91oip3pGvWlN+xKsc7xudq8z0i7QKenff6DGjduf9mN2aQQ1teU7lrsygt6c7Ozrj136U8Wj+GJx3HvSkl/mhJ7l3sXRfj3dmpt6U2KF9gPdV7q97vNOz6t7Eu/vTh6bfLXaBn+CPx/jJe3z/YvzkEsXZ7H7lDZXxxUmJ4nJP2/MC1RdI32BKVMlP3/MCxRdI32BKFMFP2/MC1RdI32BKVMlP3/MCxRdI32BKFMFP2/MC1RdI32BKVMlP3/MCxRdI32BKFMFP2/MC1RdI32BKVMnWF1xLPcfnBZov4N/g/wAAAP//5Bg7CwAACvdJREFU7VsNb1s5DOv//9N30UMZsJRsy7acJt3bYaA+SEp23Aw7YF//fX39x7+/in6d8Cxa7bZ5sxvgt2Lx47/zj5JnvNl93OvIDeCzkvLRFDOB96M8et2fZ46HAXzFCTAL+NJH+YoD3jP2bgAPg5EdW3XmzMbsafH9KGdv8I/z9YFwjqNz7XpEaCyi83OFRWOVqW/V8jpnN8eeuz4Z/StnZfaJONhRUbnat1w52Vy9PuqbkpfPHrjHYz+Le9yKHs+r8DvhwTuO7kS5yGf3gg74sY/SDjB7eObjAhSZcyLmeSf8dz15P4tHfspHPtJxHxrgRz9KHKIa+cKqY9212n/Xb2U/1SDP7gI+8H6Uj28DXAYwe5mrPMwBrvqc0GEnYGYGuIoZrXGczhWyTgOe+lo+kAzblZ6VXsPFhfCbs2UVl+pujtAoqM7yBtWVVetfqZOsFXTQzJKtiZWelV6tfXv1357f2k33avG0rjrLldPKVXs/ysfl4VJal3aijpmKJ2bNeO7ss6p1OleYOUGHq76Wd+ipVqVnpVdqeSFF860mtJenutfMAqxd1V13wEZXYcatw1XfCu9Kz0qvzjV0W9EOFffUHTpo6k4Dumuv7O9muoIbs1ZQ35VldXKlZ6WX7pnNox0q7ik7P+LpThEnU4PPDPepQQDMmGQ48GPs6YzX61uPvRCPNK0+9Iwt7qk6z0Z8albWF3sAszrlQW+oPc2Ze/FdQRWLufpewxpezG1QrjLzEPf4vR70jD3+iR7PRnxizown9gDOaMGFlhG9CJlnsfv2iUQrNR10DQuMsjyTznCDUT9KlV4/jCcT3mNSeoTO+yCeGQRNhC0f5boPOhKq6BV5do+Il6lFZ8joqjnYY+QL3qdjdE49U+pRmpEKX5HrAaKZysnmlV7Zmbu8aOdPq0V3oGdwjy0SoQYx8h6Cy9jjZ3rshTijizjQM0a8d6th35N7YQbw5CzzxhygLxRtgAGMu9bshXjVE3rGVa+/puM7sfj0+dw8VyjYQD2R71rDh3HVkz0Qr3r9NR3uA3j6fJgDPPJNCXPF3cOpn+WrnpVeqzu8q07v5vSebp4rFGygnsh3reHDuOrJHohXvf6aDvcBPH0+zAHe35SPb9vnZZy+/Q/xx30AT6+NOcDyRwnjCHcPV+lZ6bV7rnfT692c3s/Nc4XNDdSP801r9wNk3quevBfiVa9d3W/P1/2xD1D71TnmAN0HvTsQxhGe8F71PLHfyi66x4pHtebVO7l5rrB5QvWL8tUR7+pVeR6ccdVzVmfzVIMdGJVTmfMci0u/KdV8lM8eLPKb9QC/0guehpHvSo09T8XYS/1RZ1ROZc5zLHaXuDNMzTU3b61dSySH7mh1RKVXxjua16qp34lcZ/MM7VnO/epY57lHsjNQzTWHt9aRo99C8Bhb3FGdPRCPNCf6mA08MUM9MUuReb0e8ypiN8sVFqeoT5SzddRHjXkco8/I/ZmYPRDP6Ku4mA3s+YJzEjFfZ6B+At0sV1icqj5RrtYRBzXlWo4eY8TL1NgDcUZXzcFs4MgfvJNoO6j/aK+dvpvlCovu6hPlkXXEQ035qDMqJ5uzB+KstpKH2cCMd4YLDmPGGxzWWYz6CXSzXGFhauShNctb1hE34iuv5Zepq1c0L+Ozy9E9dv2gV9/Z8+3qsUcGdVbJ17QzfWyiNct7C2b4yun5jXrqZflIc6Kve1TNUN/Z8+3qZ86hs9zjmTED15k+GlqzHPwIM3zlRD7ZmnpZntVW8nSPKm/1XTmfelTtpj5ujiuoYpC39Fq3fGDlHrLy1VP7M7l6Zfab8c9ydY+sbsRT35Xzqcdo5mrfzXGFSeeWXuuWZ6yhi7joASNOtgYPxqy2ksfzLa7yVt8Vb/Wo2k193BxXUEUn72m1Z3nHKtVSz5SoQVKviv0ao7pl3aNLnmiq78r5KjwyK+uc4R+ZPVNnRmTtWU7tpVA9l0y+RepVsd/KPrrHikekUd/V86lPNGu35ma4wsQE1qqMe4iVM5vDBzirZz48GLn/qpjnW1w1V31XvdWnaj/2cTNcgdmdeKTTvuUdu2Hr3f2GB2gQ9FwN2nRZfS2fNnkI1GfFY6RxM1xh5PDdZ10k4T7iiJetwYMxq4147IM44p2uYTawah78GFe8WY94xaengS9w6ScBYsPWMOYgbnEzdXgAM5oeBz6MPf6pHs+3uGqO+u54q1fVjvBx/q4AZgdZ06IxB3GLm6nDA5jR9DjwYezxT/V4vsVVc9R3x1u9qnaEj/N3BTAbyPwG5SozD3GPP+rBAzjij/rwYRxpTvR5vsVVM9R3x7vSKzqf+tstPP/dc2Zx5kcDUGMeYvRmEXrGWQ/lsxdi5bwix2xgduaIjz5j1jvisY/FEWe15rxdoePM3A7tajEX8UjT6kMPbPFm6vBizOpNk+WOeDw/6wtNzxscxh5/1GMfxCMN903DOcfwA059Uz5F7NiIwWVsUIdl9rB4KEgQ1HPGd4Y7WkX3yPKzPPYfaXp99kHc42vPNFpDDj9g+lE+BXAaIPiMA0mzzR4WN4kTDfXM+kI3MapLhR+wRwbHsMezHnMRjzSjPnwYRxr0TYNYkf0uniuo4jsHr9F2ZfAZHSlRYL3FCUmKor5Zb+hSQxIk+AFbEvQNWxyuMx8x91sxuIbK4R5i5UT5iIs+0CYP/6IDTjSwVYOGscXt1VlvcY8701PfrDd0M7N6XPgBIy56hlE/qrEGccSzGvqMFVx4wBe5IvpAt1BLoPVRjgGMI432WWux9ndy9c76Q7czm7XwA3LPYtSB2m/l4DOCyzWO0e8h8xH3+NYb8dAHPgXPgkywupRSKfwYU0IisdZiam2H6p31h257gW8D+AHZFzUg90YxNBkceWk/8lQO5+BzjWP0gcNHyeKZGAMYZ/TG3dGOZrE34pGGd8pwMxzMBkKDHIh6FqHrYdZLeS1P5SEHH7ki+sAfH7wVVbCaYwDjjBfrLJ7RZrjqn53BusycEYf9eIdWveenmijv6Wd6WW/mtfyZY/FHPMrWYXbqehHXZSQMWZegDynshx2iWmSkvF4e6XdqrVnqyTztIWeOxW/5KN2S2L4QdcZ1GQl/1iXoQwr7RTEbRP1RjfXVcWs2z2EO1zlmjsVv9yjdgrx9YaxzrstI+KsuIWlS1CvKVRxxoprqTuXRbKthHvdRU2TOpXUFVSzm6nsNS3ixLkFfpvAcxCMz8BRHulZffTSPdMrRPNKcrOl8zm2u5tEuzLH4h+gqRKqFmg7KeLNmYeSUhGdx3DNhnsY9XaunHpy3NFZnHuIe/3QPO4ywtYfq3AFbwtm6DrK856H8Hreip/N28tV9ejNHntCOeK/qY58etnZRzVs+ytby1XW9jJV8d6doZsYTugz3VRzs1MLWHsp/i0fJS7UWP1Xn2bNx1U46t8r3N3z0LJy39mGOxb/+KHmh1tKn67xDJj6xD+ae8H61J86i2NrD8VyhpZysq6/lagGO1v/VPLqjT70LfLaK0XkcxxUi1UJNfS1nG/S5dsd/7wbwOQOjE6IHfNkf37zMczgX7/jP3gA+b8PokNy/OK4QqRZq8F2Q3pJ/7AbwVoDHvin/sXu9j7txA3iMwPtRblzmLa25ATxG4P0oa+71dtm4ATxG4P0oNy7zltbcAB4j8H6UNfd6u2zcAB4j8H6UG5d5S2tuAI8R6B4lGjf+/Pfw93287j7uR/n4H7r3g3uvO7gf5f0o3+6H8n6U96N8u0f5P4icW8Y+jDvSAAAAAElFTkSuQmCC")
            };
            var response = await Service.AppSignContractAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task CompletionContractTest()
        {
            var request = new CompletionContractRequest
            {
                ContractId = "201809131827"
            };
            var response = await Service.CompletionContractAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }

        [Fact]
        public async Task UndoContractTest()
        {
            var request = new UndoContractRequest
            {
                ContractId = "201809131827"
            };
            var response = await Service.UndoContractAsync(request);

            Assert.NotNull(response);
            Assert.Equal(ErrorCode.Success, response.Code);
        }
    }
}
