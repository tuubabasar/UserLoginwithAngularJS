using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using API.Function;
using Microsoft.AspNet.Identity;
using Model.Model;

namespace API.Controllers
{
    [EnableCorsAttribute("https://localhost:44357/", "*", "*")]//https://localhost:44357/(UI localhost'u) domaininden gelen tüm  isteklerine cevap verir. Bunu kullanabilmek için "using System.Web.Http.Cors;" eklendi.
    public class UsersController : ApiController    {

        private UserContext db = new UserContext();
        
        [HttpGet]
        [Route("api/users/{username}/{password}/{LastLoginTime}/{State}/{LastUpdateDate}/{RecordState}/{HType}")]
        //Giriş yapıldığında adres çubuğunda bu formatta yazılacaktır ve veriler öyle çekilecektir.
        public IHttpActionResult Login(string UserName, string Password, DateTime LastLoginTime, int State, DateTime LastUpdateDate, int RecordState, string HType)
        {
            int sayac = 0;
            if (string.IsNullOrEmpty(UserName) || 
                string.IsNullOrEmpty(Password))  //Kullanıcı adı veya şifre boş geçilirse uyarı verecek.
            {
                return BadRequest("Lütfen kullanıcı adı ve şifre girin");
            }
            else
            {
                try
                {
                    UserFunction user = new UserFunction();
                    int UserId = user.GetUserIdByLogin(UserName,Password, LastLoginTime,State, LastUpdateDate, RecordState, HType);
                    if (UserId>0)//giriş başarılı olursa aşağıdaki bilgiler databasede güncellenecek
                    {
                        LastLoginTime =DateTime.Now;
                        LastUpdateDate = DateTime.Now;
                        State = 1;
                        RecordState = 1;
                        db.SaveChanges();
                        return Ok(UserId);
                    }
                    else
                    {
                        sayac++;
                        LastUpdateDate = DateTime.Now;
                        if (sayac==3)//eğer 3 kere hatalı giriş yapılırsa bu bloğa girecek ve hesap bloke olacak.
                        {
                            State = 2;
                            LastUpdateDate = DateTime.Today;
                            db.SaveChanges();
                            return BadRequest("Hesabınız bloke olmuştur.");
                        }
                        return BadRequest("Lütfen kullanıcı adı ve şifrenizin doğruluğunu kontrol edin");

                    }
                    
                }
                catch (Exception ex)
                {

                    return InternalServerError(ex);
                }
            }
        }

    }
}