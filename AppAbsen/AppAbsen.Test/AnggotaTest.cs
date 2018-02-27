using AppAbsen.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAbsen.Test
{
    [TestClass]
    public class AnggotaTest
    {
        private AnggotaViewModel context;

        public AnggotaTest()
        {
            context = new ViewModels.AnggotaViewModel(new Library.DTO.user());
            context.Agama = Library.Kepercayaan.Hindu;
            context.Alamat = "Mana";
            context.AsalSekolah = "Manakek";
            context.AsalUniversitas = "AuAh";
         
            context.IdUnitKerja = "01";
            context.JenisKelamin = Library.Gender.Wanita;
            context.Nama = "Amrin";
            context.TempatLahir = "Buton";
            context.TglLahir = DateTime.Now;
        }

        [TestMethod]
        public void AddAnggota_true_true()
        {
            context.IdMahasiswa = "0123456";
            var result = context.SaveCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if (result)
            {
                context.SaveCommand.Execute(null);
                Assert.AreEqual(false, context.SourceView.IsEmpty);
            }

        }

        [TestMethod]
        public void UpdateAnggota_true_true()
        {
            context.IdMahasiswa = "0123456";
            context.Nama = "Ajen";
            var result = context.EditCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if (result)
            {
                context.EditCommand.Execute(null);
                Assert.AreEqual(false, context.SourceView.IsEmpty);
            }

        }



        [TestMethod]
        public void DeleteUnitKerja_true_true()
        {
            context.IdMahasiswa = "0123456";
            var result = context.DeleteCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if (result)
            {
                context.DeleteCommand.Execute(null);
                Assert.AreEqual(true, context.SourceView.IsEmpty);
            }

        }



        [TestMethod]
        public void NewUnitKerja_true_true()
        {
            context.IdUnitKerja = "01";
            var result = context.NewCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if (result)
            {
                context.NewCommand.Execute(null);
                Assert.IsTrue(string.IsNullOrEmpty(context.IdUnitKerja));
            }

        }






    }
}
