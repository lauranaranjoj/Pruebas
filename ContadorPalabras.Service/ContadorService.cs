using ContadorPalabras.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContadorPalabras.Service
{
    public class ContadorService
    {

        public ResultadoDTO ContarPalabras(string texto)
        {
            try
            {
                List<ItemDTO> listItems = new List<ItemDTO>();
                ResultadoDTO objResultado = new ResultadoDTO();
                objResultado.Items = listItems;
                objResultado.Exitoso = true;

                texto = texto.Replace(".", "");
                texto = texto.Replace(",", "");
                texto = texto.Replace("\n", " ");

                string[] arrayPalabras = texto.Split(' ');

                foreach (string p in arrayPalabras)
                {
                    string palabra = p.Trim();

                    if(palabra != "")
                    {
                        if (listItems.Where(x => x.Palabra.ToUpper() == palabra.ToUpper()).Count() == 0)
                        {
                            ItemDTO objItem = new ItemDTO(palabra.ToUpper());
                            objItem.Cont = 1;
                            listItems.Add(objItem);
                        }
                        else
                        {
                            listItems.Where(x => x.Palabra.ToUpper() == palabra.ToUpper()).First().Cont += 1;
                        }
                    }
                }

                return objResultado;
            }
            catch(Exception ex)
            {
                return new ResultadoDTO(ex.Message);
            }
        }
    }
}
