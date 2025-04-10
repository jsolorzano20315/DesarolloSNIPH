using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace PruebaPOPA
{
    public static class StaticResources
    {
       
        #region USUARIOS 

        #region Guardar Usuario  

        public static string QueryGuardarUsuario = @"                					
			 INSERT INTO [dbo].[Usuarios]
                       ([nombre]
                       ,[email]
                       ,[password]
                       ,[rol] 
                       ,[fecha_creacion]
                       ,[fecha_modificacion]
                       ,[usuario_creacion]
                       ,[usuario_modificacion]
                       ,[estado])
                 VALUES
                       (@nombre
                       ,@email
                       ,@password
                       ,@rol
                       ,@fecha_creacion
                       ,@fecha_modificacion,
                       ,@usuario_creacion,
                       ,@usuario_modificacion,
                       ,@estado)
			";

        #endregion

        #region Modificar Usuario   

        public static string QueryModificarUsuario = @"                					
			UPDATE [dbo].[Usuarios]
                   SET [nombre] = @nombre
                      ,[email] = @email
                      ,[password] = @password
                      ,[rol] = @rol
                      ,[fecha_modificacion] = @fecha_modificacion
                      ,[usuario_modificacion] = @usuario_modificacion
                 WHERE id_usuario = @id_usuario
			";

        #endregion

        #region Listar Usuario 

        public static string QueryListarUsuario = @"                					
			SELECT [id_usuario]
                  ,[nombre]
                  ,[email]
                  ,[password]
                  ,[rol]
              FROM [dbo].[Usuarios]
							";
        #endregion

        #region Eliminar Usuario

        public static string QueryEliminarUsuario = @"                					
			DELETE FROM [dbo].[Usuarios]
                      WHERE id_usuario = @id_usuario
							";

        #endregion

        #endregion

        #region LOGIN 

        public static string QueryUserLogin = @"                  					
			SELECT [id_usuario]
                  ,[nombre]
                  ,[email]
                  ,[password]
                  ,[rol]
              FROM [dbo].[Usuarios]
                WHERE nombre = @nombre and password = @password
							";
        #endregion


    }
}
