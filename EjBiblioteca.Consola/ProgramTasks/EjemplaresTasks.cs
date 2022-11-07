﻿using EjBiblioteca.Consola.ProgramHelper;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio;
using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola.ProgramTasks
{
    public class EjemplaresTasks
    {
        // traemos por consola todo el listado de ejemplares
        public static void ListarEjemplares(BibliotecaNegocio bibliotecaServicio)
        {
            List<Ejemplar> list = bibliotecaServicio.TraerTodosEjemplares();

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            Console.WriteLine("\r\nLista de Ejemplares:");

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Ejemplar", "ID Libro", "Observaciones", "Precio", "Fecha Alta");
            OutputHelper.PrintLine();

            foreach (var item in listaOrdenadaPorId)
            {
                OutputHelper.PrintLine();
                OutputHelper.PrintRow(item.Id.ToString(), item.IdLibro.ToString(), item.Observaciones, item.Precio.ToString(), item.FechaAlta.ToString());
            }
            OutputHelper.PrintLine();
        }

        public static void ContarEjemplaresPorLibro(BibliotecaNegocio bibliotecaServicio)
        {
            int count = 0;

            int idLibro = InputHelper.IngresarNumero<int>("el ID del libro");

            List<Ejemplar> list = bibliotecaServicio.TraerTodosEjemplares();

            foreach (var item in list)
            {
                if (item.IdLibro == idLibro) count++;
            }

            if (count > 0)
                Console.WriteLine("\r\nEl libro con ID " + idLibro + " tiene " + count + " ejemplares\r\n");
            else
                Console.WriteLine("\r\nNo se ha encontrado ningun ejemplar para el libro con ID: " + idLibro);
        }

        // traemos por consola todo el listado de ejemplares para un libro
        public static void ListarEjemplaresPorLibro(BibliotecaNegocio bibliotecaServicio)
        {
            int idLibro = InputHelper.IngresarNumero<int>("el ID del libro");

            List<Ejemplar> list = bibliotecaServicio.TraerTodosLosEjemplaresPorLibro(idLibro);

            var listaOrdenadaPorId = list.OrderBy(x => x.Id).ToList();

            OutputHelper.PrintLine();
            OutputHelper.PrintRow("ID Ejemplar", "ID Libro", "Observaciones", "Precio", "Fecha Alta");
            OutputHelper.PrintLine();

            foreach (var item in listaOrdenadaPorId)
            {
                OutputHelper.PrintLine();
                OutputHelper.PrintRow(item.Id.ToString(), item.IdLibro.ToString(), item.Observaciones, item.Precio.ToString(), item.FechaAlta.ToString());
            }
            OutputHelper.PrintLine();
        }

        public static void AltaEjemplar(BibliotecaNegocio bibliotecaServicio)
        {
            int idLibro = InputHelper.IngresarNumero<int>("el ID del libro");
            Console.WriteLine("\r\nIngrese las observaciones del ejemplar");
            string observaciones = Console.ReadLine();
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");
            DateTime fechaAlta = InputHelper.IngresarFechaPasoAPaso();

            Ejemplar insertEjemplar = new Ejemplar(idLibro, observaciones, precio, fechaAlta);

            Console.WriteLine("\r\nEjemplar cargado:\r\n" + insertEjemplar.ToString());
            string confirmacion = InputHelper.confirmacionABM("ejemplar", "insertar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                bibliotecaServicio.InsertarEjemplar(insertEjemplar);

                Console.WriteLine("\r\nEjemplar Insertado!\r\nResultado final:\r\n" + insertEjemplar.ToString());
            }
        }

        public static void ModificarEjemplar(BibliotecaNegocio bibliotecaServicio)
        {
            int id = InputHelper.IngresarNumero<int>("el ID del ejemplar");
            Console.WriteLine("\r\nIngrese las observaciones del ejemplar");
            string observaciones = Console.ReadLine();
            double precio = InputHelper.IngresarNumero<double>("el precio del ejemplar");

            Ejemplar modificarEjemplar = new Ejemplar(id, observaciones, precio);

            Console.WriteLine("\r\nEjemplar cargado:\r\n" + modificarEjemplar.ToString());
            string confirmacion = InputHelper.confirmacionABM("ejemplar", "actualizar");

            if (confirmacion == "S" || confirmacion == "s")
            {
                bibliotecaServicio.ActualizarEjemplar(modificarEjemplar);

                Console.WriteLine("\r\nEjemplar " + id + " modificado!\r\n\r\nResultado final:\r\n" + modificarEjemplar.ToString());
            }
        }
    }
}
