﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjBiblioteca.Consola
{
    public static class MenuHelper
    {

        public static void DesplegarBienvenida()
        {
            Console.Write("Bienvenido al Sistema de la Biblioteca General Jeremias Springfield \r\n");
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.Write("\r\nPara continuar, seleccione la opción deseada y presione Enter: \r\n");
            Console.Write("1. Listar Ejemplares \r\n2. Contar Ejemplares Por Libro \r\n3. Listar Ejemplares Por Libro \r\n4. Alta Ejemplar\r\n5. Modificar Ejemplar \r\n6. Listar Libros \r\n7. Listar Libro por ID \r\n8. Alta Libro \r\n9. Listar Prestamos \r\n10. Listar Prestamos por Libro \r\n11. Listar Prestamos por Cliente \r\n12. Alta Préstamo \r\n13. Modificar Préstamo \r\n14. Baja Préstamo\r\n15. Listar Clientes\r\n16. Alta Cliente \r\n17. Modificar Cliente \r\n18. Baja Cliente\r\n19. Listar Cliente Por Telefono\r\n20. Modificar Cliente por ID\r\nX. Para salir \r\n"); 
        }
    }
}