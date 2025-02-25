Proyecto Backend utilizando JWT

Este proyecto es una API en ASP.NET Core que implementa autenticación mediante JWT (JSON Web Token) y usa una base de datos SQL Server para almacenar usuarios, probandolo en 
postman no deja que el usuario vea los datos sin tener antes el token para asi poder observar los datos.

Tecnologías utilizadas:

ASP.NET Core

JWT (JSON Web Token)

SQL Server

WEB API CORE

SQL CLient

JWT (JSON Web Token)



Instalación y configuración

Para instalar este proyecto solo debe de contar con Visual Studio 2022, postman para pruebas, instalar los paquetes Nuget que son:

System.IdentityModel.Tokens.Jwt     {6.36.0}                                                                                                 
Microsoft.AspNetCore.Authenticat... {6.0.30}                                                                                                 
Swashbuckle.AspNetCore              {6.6.2}                                                                                                  
System.Data.SqlClient               {4.9.0}      

se utilizaron algunas Versiones por cuestiones de compatibilidad con .NET 8.



USO DE LA API:

En autenticacionController existe un meotdo llamado validar, dentro de el estan correo y clave, sustituyalas por las que ustede desee, ya que se esta de manera estatica.
y hace las pruebas en postman.






