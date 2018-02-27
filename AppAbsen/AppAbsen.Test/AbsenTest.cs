using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAbsen.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppAbsen.Test
{
    [TestClass]
    public class AbsenTest
    {
        private MenuUtamaViewModel context;

        public AbsenTest()
        {
            context = new MenuUtamaViewModel(new Library.DTO.user());
        }


        [TestMethod]
        public void AddAnggota_true_true()
        {
            context.IdAnggota = "0123456";
            var result = context.AbsenCommand.CanExecute(null);
            Assert.AreEqual(true, result);
            if (result)
            {
                context.AbsenCommand.Execute(null);
                Assert.AreEqual(false, context.SourceView.IsEmpty);
            }

        }

    }
}
