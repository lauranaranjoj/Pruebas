using System;
using System.Collections.Generic;
using System.Text;

namespace ContadorPalabras.Shared.DTO
{
    public class ResultadoDTO
    {

        public ResultadoDTO()
        {

        }

        public ResultadoDTO(string exception)
        {
            Error = exception;
            Exitoso = false;
        }

        public bool Exitoso { get; set; }

        public string Error { get; set; }

        public List<ItemDTO> Items { get; set; }
    }
}
