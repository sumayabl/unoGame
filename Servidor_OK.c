#include <mysql.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

MYSQL *conn;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct {
	
	char nombre [20];
	int socket;
}Conectado;

typedef struct {
	
	int num;
	Conectado conectados[100];
	
}ListaConectado;

ListaConectado lista;

typedef struct {
	char mensaje [100];
}Chat;

typedef struct{
	int num;
	Chat mensajes[500]; 
}ListaMensajes;

ListaMensajes lista2;

int conectarMysql(){
	
	int err;
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	//inicializar la conexion, indicando nuestras claves de acceso
	// al servidor de bases de datos (user,pass)
	conn = mysql_real_connect (conn, "localhost","root", "mysql", NULL, 0, NULL, 0);
	if (conn==NULL)
	{
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query(conn,"create database if not exists Game");
	if (err!=0)
	{
		printf ("Error al crear la base de datos %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query(conn,"use Game;");
	if (err!=0)
	{
		printf ("Error al entrar en la base de datos %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	err=mysql_query(conn,"CREATE TABLE if not exists Player (ID_Player INTEGER PRIMARY KEY AUTO_INCREMENT, username VARCHAR(10) not null, password VARCHAR(10) not null);");
	if (err!=0)
	{
		printf ("Error al definir la tabla %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
}

int sockets[100];

void *AtenderCliente(void *socket){
	
	int e = 1;
	while (e>=1){
		
		int sock_conn;
		char buff[512];
		char buff2[512];
		int ret;
		
		int *s;
		
		s = (int *) socket;
		sock_conn = *s;
		
		int i=1;
		char user [20];
		
		while(i>=1){
			
			// Ahora recibimos su nombre, que dejamos en buff
			ret=read(sock_conn,buff, sizeof(buff));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			buff[ret]='\0';
			
			//Escribimos el nombre en la consola
			
			printf ("Se ha conectado: %s\n",buff);
			
			char *p = strtok( buff, "/");
			char num[20];
			strcpy (num, p);
			p = strtok( NULL, "/");
			char usuario[20];
			strcpy (usuario, p);
			p = strtok( NULL, "/");
			char password [20];
			strcpy (password, p);
			printf ("Numero: %s, Codigo: %s, Nombre: %s\n", num, usuario, password);
			
			int numero = strcmp(num,"1");
			int numero2 = strcmp(num,"2");
			
			int err;
			if (numero == 0)
			{
				//usuario quiere registrarse
				char part [200];
				strcpy (part,"insert into Player values (NULL,'");
				strcat (part, usuario);
				strcat (part, "','");
				strcat (part, password);
				strcat (part, "');");
				
				err = mysql_query(conn, part);
				if (err!=0)
				{
					printf ("Error al introducir los datos %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					strcpy(buff2,"1/NO");
					printf ("%s\n", buff2);
					// Y lo enviamos
					write (sock_conn,buff2, strlen(buff2));
				}
				else 
				{
					printf("Se ha registrado correctamente\n");
					strcpy (buff2,"1/SI");
					printf ("%s\n", buff2);
					write (sock_conn,buff2, strlen(buff2));
				}
			}
			else if (numero2 == 0)
			{
				MYSQL_RES *resultado;
				MYSQL_ROW row;
				char consulta [100];
				
				// construimos la consulta SQL
				strcpy (consulta,"SELECT password FROM Player WHERE username = '"); 
				strcat (consulta, usuario);
				strcat (consulta,"';");
				// hacemos la consulta 
				err=mysql_query (conn, consulta); 
				if (err!=0) {
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
				}
				//recogemos el resultado de la consulta 
				resultado = mysql_store_result (conn); 
				row = mysql_fetch_row (resultado);
				if (row == NULL)
				{
					printf ("No se han obtenido datos en la consulta\n");
					strcpy (buff2,"2/NO");
					
					printf ("%s\n", buff2);
					// Y lo enviamos
					write (sock_conn,buff2, strlen(buff2));
				}
				else
				{
					printf("%s\n",row[0]);
					// El resultado debe ser una matriz con una sola fila
					// y una columna que contiene el nombre
					// cerrar la conexion con el servidor MYSQL 
					int pas = strcmp(password, row[0]);
					
					if(pas == 0) 
					{
						strcpy (buff2,"2/SI/");
						i=0;
						
						strcpy(lista.conectados[lista.num].nombre,usuario);
						lista.conectados[lista.num].socket = sock_conn;
						lista.num++;
						
						int f =0;
						while(f<lista.num){
							printf("%s\n",lista.conectados[f].nombre);
							f++;
						}
						
						strcpy(user,usuario);
						strcat(buff2,usuario);
						write (sock_conn,buff2, strlen(buff2));
						
						strcpy (buff2,"5/");
						char str[12];
						sprintf(str, "%d",lista.num);
						strcat(buff2,str);
						strcat(buff2,"/");
						
						int d=0;
						while (d<lista.num){
							strcat(buff2,lista.conectados[d].nombre);
							strcat(buff2,"/");
							d++;
						}
						for(int j=0; j<lista.num; j++){
							write (lista.conectados[j].socket,buff2,strlen(buff2));
						}
					}	
					else{
						strcpy (buff2,"2/NO");
						printf ("%s\n", buff2);
						// Y lo enviamos
						write (sock_conn,buff2, strlen(buff2));
					}
				}
			}
		}
		
		int m=1;
		
		while(m>=1){
			
			printf ("Recibido\n");
			ret=read(sock_conn,buff, sizeof(buff));
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			buff[ret]='\0';
			//Escribimos el nombre en la consola
			
			printf ("Se ha conectado: %s\n",buff);
			char *p = strtok( buff, "/");
			char num[20];
			strcpy (num, p);
			
			int numero3 = strcmp(num,"3");
			int numero4 = strcmp(num,"4");
			int numero5 = strcmp(num,"5");
			int numero6 = strcmp(num,"6");
			int numero7 = strcmp(num,"7");
			
			//boton actualizar
			if (numero3 == 0){
			
			strcpy(buff2,"3/");
			char str[12];
			sprintf(str, "%d",lista.num);
			
			int d=0;
			strcat(buff2,str);
			strcat(buff2,"/");
			while (d<lista.num){
				strcat(buff2,lista.conectados[d].nombre);
				strcat(buff2,"/");
				d++;
			}
			write (sock_conn,buff2, strlen(buff2));
			}
			
			//boton cerrar sesion
			if (numero4 == 0){
				
				int f =0;
				while(f<lista.num){
					int p = strcmp(lista.conectados[f].nombre,user);
					if(p == 0){
						while(f<lista.num){
							strcpy(lista.conectados[f].nombre,lista.conectados[f+1].nombre);
							lista.conectados[f].socket = lista.conectados[f+1].socket;
							f++;
						}
						lista.num --;
					}
					f++;
				}
				
				char str[12];
				strcpy(buff2,"");
				strcat(buff2,"4/");
				sprintf(str, "%d",lista.num);
				m=0;
				
				int d=0;
				strcat(buff2,str);
				strcat(buff2,"/");
				while (d<lista.num){
					strcat(buff2,lista.conectados[d].nombre);
					strcat(buff2,"/");
					d++;
				}
				
				for(int j=0; j<lista.num; j++){
					write (lista.conectados[j].socket,buff2,strlen(buff2));
				}
				
			}
			
			if (numero5 == 0){
				
				p = strtok( NULL, "/");
				char jugador[20];
				strcpy (jugador, p);
				int sok;
				int d=0;
				int i;
				int h;
					
				while (d<lista.num){
					
					h = strcmp(lista.conectados[d].nombre,jugador);
					if (h == 0) {
						sok = lista.conectados[d].socket;
						i = 1;
					}
					d++;
				}
				
				if (i == 1){
					
					strcpy(buff2,"");
					strcat(buff2,"6/SI/");
					strcat(buff2,user);
					strcat(buff2,"/");
					char str[12];
					sprintf(str, "%d",sock_conn);
					strcat(buff2,str);
					write (sock_conn,buff2, strlen(buff2));
					
					strcpy(buff2,"");
					strcat(buff2,"7/");
					strcat(buff2,user);
					strcat(buff2,"/");
					char stm[12];
					sprintf(stm, "%d",sock_conn);
					strcat(buff2,str);
					write (sok,buff2,strlen(buff2));
					
				}
				else{
					
					printf("NO se ha encontrado a nadie con ese nombre\n");
					strcpy(buff2,"");
					strcat(buff2,"6/NO/");
					strcat(buff2,user);
					strcat(buff2,"/");
					char str[12];
					sprintf(str, "%d",sock_conn);
					strcat(buff2,str);
					write (sock_conn,buff2, strlen(buff2));
				}
			}
			
			
			if (numero6 == 0){
				
				p = strtok( NULL, "/");
				char respuesta[20];
				strcpy (respuesta, p);
				p = strtok( NULL, "/");
				char jugador[20];
				strcpy (jugador, p);
				p = strtok (NULL, "/");
				char su_socket[20];
				strcpy (su_socket,p);
				
				int d =0;
				int sok;
				int i ;
				char dE [2] = "SI";	
				
				
				while (d<lista.num){
					
					int h = strcmp(lista.conectados[d].nombre,jugador);
					if (h == 0){
						sok = lista.conectados[d].socket;
						i = 1;
					}
					d++;
				}
				if (i == 1){
					
					int r = strcmp(respuesta,dE);
					
					if (r == 0){
						
						strcpy(buff2,"");
						strcat(buff2,"8/SI/");
						strcat(buff2,user);
						strcat(buff2,"/");
						char str[12];
						sprintf(str, "%d",sock_conn);
						strcat(buff2,str);
						write (sok,buff2,strlen(buff2));
						
						strcpy(buff2,"");
						strcat(buff2,"9/SI/");
						strcat(buff2,user);
						strcat(buff2,"/");
						char stm[12];
						sprintf(stm, "%d",sock_conn);
						strcat(buff2,stm);
						write (sock_conn,buff2, strlen(buff2));
					}
					else 
					{
						strcpy(buff2,"");
						strcat(buff2,"8/NO/");
						strcat(buff2,user);
						write (sok,buff2,strlen(buff2));
					}
				}
			}
			if (numero7 == 0){
				
				p = strtok( NULL, "/");
				char mensaje [100];
				strcpy (mensaje, p);
				p = strtok (NULL, "/");
				int s = atoi(p);
				strcpy(lista2.mensajes[lista2.num].mensaje,mensaje);
				lista2.num ++;
				
				strcpy(buff2,"");
				strcat(buff2,"10/");
				
				char str[12];
				sprintf(str, "%d",lista2.num);

				strcat(buff2,str);
				strcat(buff2,"/");
				
				int d =0;
				while (d<lista2.num){
					strcat(buff2,lista2.mensajes[d].mensaje);
					strcat(buff2,"/");
					d++;
				}
				
				write (s,buff2, strlen(buff2));
				write (sock_conn,buff2, strlen(buff2));
			}
		}
		
	}
	//sock_conn es el socket que usaremos para este cliente
	
}


int main(int argc, char *argv[])
{
	
	conectarMysql();
	
	int sockets[100];
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	pthread_t thread[100];
	char buff[512];
	char buff2[512];
	
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	// INICIALITZACIONS
	// Obrim el socket
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9060);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind \n");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	int j=0;
	lista.num=0;
	lista2.num=0;
	for(;;){
		
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[j]=sock_conn;
		pthread_create(&thread[j], NULL,AtenderCliente,&sockets[j]);
		j++;
	}
}

