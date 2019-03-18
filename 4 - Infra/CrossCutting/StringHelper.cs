using System;
using System.Globalization;

namespace CrossCutting
{
    public static class StringHelper
    {
        public static string CompletarCamposComZeros(decimal valor, int quantidadeDeCampos) => valor.ToString()
            .Replace(",", "")
            .Replace(".", "")
            .PadLeft(quantidadeDeCampos, '0');

        public static string CompletarCamposComZeros(int valor, int quantidadeDeCampos) => valor.ToString().PadLeft(quantidadeDeCampos, '0');

        public static string FormatarDataParaArquivoDeEmprestimos(DateTime data) => data.ToString("yyyyMMdd");

        public static string RetornarQuantidadeDeCmaposDecimais(decimal valor, int quantidadeDeCampos) => CompletarCamposComZeros(Math.Round(valor, 2), quantidadeDeCampos);
    }
}