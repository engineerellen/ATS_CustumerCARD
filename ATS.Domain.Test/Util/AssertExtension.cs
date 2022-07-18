using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ATS.Domain.Test.Util
{
    public static class AssertExtension
    {
        public static void ValidarMensagem(this ArgumentException argumentException, string mensagemError)
        {
            if (argumentException.Message == mensagemError)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true, $"A mensagem esperada é {mensagemError}");
            }
        }
    }
}
