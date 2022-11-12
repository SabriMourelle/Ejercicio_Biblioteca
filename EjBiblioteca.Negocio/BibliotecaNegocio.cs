﻿using EjBiblioteca.Datos;
using EjBiblioteca.Entidades;
using EjBiblioteca.Negocio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Negocio
{
    public class BibliotecaNegocio
    {
        // generamos un bibliotecaNegocio muy basico para arrancar y primeras llamadas a la API
        private EjemplarDatos _ejemplarDatos;
        private PrestamoDatos _prestamoDatos;
        private LibroDatos _libroDatos;

        //private PrestamoDatos _prestamoDatos;

        public BibliotecaNegocio()
        {
            _ejemplarDatos = new EjemplarDatos();
            _libroDatos = new LibroDatos();
            _prestamoDatos = new PrestamoDatos();
        }

        //NEGOCIO EJEMPLARES 
        public List<Ejemplar> TraerTodosEjemplares()
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodos();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenEjemplares();
        }

        public List<Ejemplar> TraerTodosLosEjemplaresPorLibro(int idLibro)
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodosPorLibro(idLibro);

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenEjemplares();
        }

        public void InsertarEjemplar(Ejemplar ejem)
        {
            if (ejem.FechaAlta < DateTime.Today.AddDays(1)) {

                List<Ejemplar> list = _ejemplarDatos.TraerTodos();

                bool flag = true;

                // TODO: VALIDAR QUE EL LIBRO EXISTA

                if (flag == true)
                {
                    ABMResult transaction = _ejemplarDatos.Insertar(ejem);

                    if (!transaction.IsOk)
                        throw new Exception(transaction.Error);
                }
                else
                    throw new LibroInexistente();
            }
            else {
                throw new FechaMayorActualException();
            }

        }

        public void ActualizarEjemplar(Ejemplar ejem)
        {
            List<Ejemplar> list = _ejemplarDatos.TraerTodos();

            bool flag = false;

            foreach (var item in list)
            {
                if (item.Id == ejem.Id) {
                    flag = true;
                }
            }
            if (flag == true) {
                ABMResult transaction = _ejemplarDatos.Actualizar(ejem);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else 
                throw new EjemplarInexistente();
        }



        // NEGOCIO LIBROS

        public List<Libro> TraerTodosLibros()
        {
            List<Libro> list = _libroDatos.TraerTodos();

            if (list.Count > 0)
            {
                return list;
            }
            else
                throw new NoExistenLibros();
        }

        public void InsertarLibro(Libro libro)
        {
            ABMResult transaction = _libroDatos.Insertar(libro);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public Libro TraerLibroPorID(int idLibro)
        {
            List<Libro> list = _libroDatos.TraerTodos();

            Libro libro = new Libro();
            bool flag = false;
            foreach (var item in list)
            {
                if (item.Id == idLibro)
                {
                    libro.Titulo = item.Titulo;
                    libro.Autor = item.Autor;
                    libro.Edicion = item.Edicion;
                    libro.Editorial = item.Editorial;
                    libro.Paginas = item.Paginas;
                    libro.Tema = item.Tema;
                    flag = true;
                }
            }
            if (flag == false)
            {
                throw new LibroInexistente();
            }
            else
                return libro;
        }

        //NEGOCIO PRESTAMOS 

        //TODO: Armar reporte por cliente
        //public List<Prestamo> TraerPrestamosPorCliente(int idCliente)
        //{
        //    List<Prestamo> list = _prestamoDatos.GetPestamos(idCliente);

        //    return list;
        //}

        public List<Prestamo> TraerPrestamos()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }

        public void InsertarPrestamo(Prestamo prest)
        {
            ABMResult transaction = _prestamoDatos.Insertar(prest);

            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        public void ActualizarPrestamo(Prestamo prest)
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            bool flag = false;

            foreach (var item in list)
            {
                if (item.Id == prest.Id)
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                ABMResult transaction = _prestamoDatos.Actualizar(prest);

                if (!transaction.IsOk)
                    throw new Exception(transaction.Error);
            }
            else
                throw new PrestamoInexistente();
        }

        public List<Prestamo> TraerTodosPrestamosPorLibro()
        {

            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();
            //se puede hacer una variable en prestamos donde se obtenga el id de libro por ejemplar? para tener ese dato disp para esta consulta
            
            return list;
            
            


        }

        public List<Prestamo> TraerPrestamosPorCliente()
        {
            List<Prestamo> list = _prestamoDatos.TraerTodosPrestamos();

            return list;
        }
    }
}
