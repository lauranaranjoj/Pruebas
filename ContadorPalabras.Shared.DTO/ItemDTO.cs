﻿using System;

namespace ContadorPalabras.Shared.DTO
{
    public class ItemDTO
    {
        public ItemDTO()
        {

        }

        //comentario de prueba

        public ItemDTO(string _palabra)
        {
            Palabra = _palabra;
            Cont = 0;
        }

        public string Palabra { get; set; }

        public int Cont { get; set; }
    }
}
