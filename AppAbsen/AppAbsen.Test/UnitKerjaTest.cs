using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppAbsen.Library.DTO;
using AppAbsen.ViewModels;

namespace AppAbsen.Test
{
    [TestClass]
    public class UnitKerjaTest
    {
        private UnitKerjaViewModel context;

        public UnitKerjaTest()
        {
            context = new AppAbsen.ViewModels.UnitKerjaViewModel(new user());
        }

        [TestMethod]
        public void AddUnitKerja_true_true()
        {
            context.IdUnitKerja = "01";
            context.NamaUnitKerja = "Apakek";
            var result = context.SaveCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if (result)
            {
                context.SaveCommand.Execute(null);
                Assert.AreEqual(false, context.SourceView.IsEmpty);
            }
             
        }

        [TestMethod]
        public void UpdateUnitKerja_true_true()
        {
            context.IdUnitKerja = "01";
            context.NamaUnitKerja ="Baru Lagi";
            var result =context.EditCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if(result)
            {
                context.EditCommand.Execute(null);
                Assert.AreEqual(false, context.SourceView.IsEmpty);
            }
           
        }


        [TestMethod]
        public void DeleteUnitKerja_true_true()
        {
            context.IdUnitKerja = "01";
            context.NamaUnitKerja = "Baru Lagi";
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
            context.NamaUnitKerja = "Baru Lagi";
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
