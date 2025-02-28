1. Descripción
	Este es un sistema desarrollado en ASP.NET Framework MCV, contiene Inicio de sesion, crud de producto con las funciones DML y algunas validaciones.

2. Requisitos
	Windows 10/11
	Microsoft Visual Studio
	.NET Framework (versión compatible con el proyecto o la mas reciente)
	SQL Server (para la base de datos)
	Bootstrap (para la interfaz de usuario)

3. Instalación
	3.1. Clonar el repositorio o descargar el código fuente
   		gh repo clone pedromendoza-system/pruebaPractica	

	3.2. Abrir el proyecto en Visual Studio.
   		Ejecutando o abriendo el archivo   "ejercicio2.cln"

	3.3. Ejecutar los scripts incluidos en el archivo "Database.txt" en el entorno "Microsoft sql server management studio" para crear la BD.

	3.3. Configurar la cadena de conexion de BASE DE DATOS en la Ruta "conexion\DataBaseConnection"
		Carpeta Conexion y en la clase DataBaseConnectio "Linea 11"
		Cambiar el valor de la variable "ruta" segun la cadena de su conexion
		Ejemplo: (ruta = "Server=localhost\\SQLEXPRESS00;Database=tubasededatos;Trusted_Connection=True;";)
		
	3.4. Compilar y ejecutar el proyecto en Visual Studio.

4. Uso
	4.1. Inicio de sesión
		Para acceder al sistema, puedes usar el siguiente usuario de prueba:
			Usuario: juanperez
			Contraseña: inter

5. Funcionalidades

	Login: Acceso al sistema con autenticación.
	Gestor de productos: Permite agregar, editar y eliminar productos.




