VERSIONES
.Net 8.0
Microsoft.EntityFrameworkCore 9.0


GUIA DE USO DE LA APLICACION

ANTES DE EJECUTARLA

	Para levantar la BD, se Debera utilizer el commando de entity "Update-Database" para que las migraciones se ejecuten y la BD levante.


LUEGO DE EJECUTARLA

	La aplicación se ejecuta en la siguiente URL: https://localhost:7138.

	CREAR UN USUARIO
	Primero, deberás registrar un usuario en la aplicación. Para hacerlo, accede a la opción "Register User" y proporciona los datos solicitados.

	INICIAR SESION
	Una vez registrado, procede a loguearte con el usuario creado. Esto te proporcionará un token de autenticación.
	Autorizar tu sesión:

	Después de iniciar sesión, haz clic en el botón "Authorize" que aparece en la parte superior derecha de la interfaz.
	En el cuadro de entrada que aparece, ingresa el siguiente formato para el token

	Bearer ElTokenObtenidoAlIniciarSesion
	(Sin comillas, reemplazando ElTokenObtenidoAlIniciarSesion con el token que obtuviste al loguearte).


	CONSULTAR EL CLIMA
	Estando logueado, podrás utilizar el endpoint WeatherApi.
	Para realizar una consulta sobre el clima, deberás especificar la latitud y longitud en los campos correspondientes. Esto te devolverá la 	información sobre las condiciones climáticas en la ubicación indicada.




NOTAS SIN RELACION A LAS INSTRUCCIONES

Entiendo que me faltaron cosas, estuve con menos tiempo de lo que pensaba estos dos dias, pense que iba a estar mas disponible, me disculpo por eso.