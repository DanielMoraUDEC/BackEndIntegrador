using BackEndIntegrador.Data;
using BackEndIntegrador.Models;
using BackEndIntegrador.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndIntegrador.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _bd;

        public UsuarioRepository(ApplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            _bd.Usuario.Update(usuario);
            return Guardar();
        }

        public bool BorrarUsuario(Usuario usuario)
        {
            _bd.Usuario.Remove(usuario);
            return Guardar();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            _bd.Usuario.Add(usuario);
            return Guardar();
        }

        public bool ExisteUsuario(string correo)
        {
            bool valor = _bd.Usuario.Any(c => c.correo.ToLower().Trim() == correo.ToLower().Trim());
            return valor;
        }

        public bool ExisteUsuario(int id_usuario)
        {
            bool valor = _bd.Usuario.Any(c => c.id_usuario == id_usuario);
            return valor;
        }

        public Usuario GetUsuario(int id_usuario)
        {
            return _bd.Usuario.FirstOrDefault(c => c.id_usuario == id_usuario);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _bd.Usuario.OrderBy(c => c.nombre).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public Usuario Login(string correo, string password)
        {
            var user = _bd.Usuario.FirstOrDefault(x => x.correo == correo);

            if (user == null)
            {
                return null;
            }

            if(!VerificaPasswordHash(password, user.pass_hash, user.salt))
            {
                return null;
            }

            return user;
        }

        public Usuario Registro(Usuario usuario, string password)
        {
            byte[] passHash; 
            byte[] passSalt;

            CreatePassHash(password, out passHash, out passSalt);

            usuario.pass_hash = passHash;
            usuario.salt = passSalt;

            _bd.Usuario.Add(usuario);
            
            Guardar();

            return usuario;
        }

        private bool VerificaPasswordHash(string password, byte[] pass_hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != pass_hash[i]) return false;
                }
            }

            return true;
        }

        private void CreatePassHash(string password, out byte[] pass_hash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                pass_hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }   
        }

    }
}
