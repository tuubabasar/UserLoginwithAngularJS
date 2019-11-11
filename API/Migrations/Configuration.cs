namespace API.Migrations
{
    using Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UserContext context)
        {
            //Login uygulamasý olduðu için manuel olarak aþaðýdaki veriler eklendi. Text dosyasýndaki username ve þifreleri kullanarak test edilecek. Þifre bilgisi hash þeklinde databasede tutulacak.
            #region Kulllanýcý Bilgilerini Database'e Ekleme
            var users = new List<User>
            {
                new User(){ Username="aktasyavuzselim", Password="dd0e5ae4f418ad6f3cbdb49745fbcdd15f28e8cc",LastLoginTime=new DateTime(2019,11,9),State=3,LastUpdateTime=new DateTime(2019,11,9),RecordState=2, HType="SHA1"},

                new User(){ Username="mertelmas", Password="ba022f2b7783bcdf15acd1e4733063456d1c349a",LastLoginTime=new DateTime(2019,11,8),State=3,LastUpdateTime=new DateTime(2019,11,8),RecordState=2,HType="SHA1"},

                new User(){ Username="kiziltasdemet", Password="dd0e5ae4f418ad6f3cbdb49745fbcdd15f28e8cc",LastLoginTime=new DateTime(2019,11,7),State=3,LastUpdateTime=new DateTime(2019,11,7),RecordState=2, HType="SHA1"},

                new User(){ Username="ezgieren", Password="5a7f8522f184bff464434f8667bfdbdd9a1e9454",LastLoginTime=new DateTime(2019,11,6),State=3,LastUpdateTime=new DateTime(2019,11,6),RecordState=2, HType="SHA1"},

                new User(){ Username="gizemunlu", Password="cafc997caa4c76ea1b23ffd9b4e2ca580b542eac",LastLoginTime=new DateTime(2019,11,7),State=3,LastUpdateTime=new DateTime(2019,11,7),RecordState=2, HType="SHA1"},

                new User(){ Username="erensevim", Password="2694065c52c88deb8ca541dca20265774ac5814b",LastLoginTime=new DateTime(2019,11,5),State=3,LastUpdateTime=new DateTime(2019,11,5),RecordState=2,HType="SHA1"},
            };

            users.ForEach(u => context.Users.Add(u));//lambda yöntemi ile database e kullanýcýlarý eklendi.
            context.SaveChanges();//databasede olan deðiþiklikler kaydedildi.

            #endregion
            context.Users.AddOrUpdate();
        }
    }
}
