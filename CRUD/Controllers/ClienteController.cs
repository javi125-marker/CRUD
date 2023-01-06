using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Models.ViewModels;


namespace CRUD.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            //Extraemos la lista del ViewModels
            List<ListClienteViewModel> lst;

            //Contexto para la conexion a la Bdd
            using(facturaEntities2 db = new facturaEntities2())
            {
                //llenado de lista
                lst = (from d in db.cliente
                       select new ListClienteViewModel
                       {
                           id_cli = d.id_cli,
                           nombre_cli = d.nombre_cli,
                           correo_cli = d.correo_cli
                       }).ToList();
            }
            return View(lst);
        }
        //Metodo para la accion Nuevo retorna a la vista
        public ActionResult Nuevo()
        {
            return View();
        }

        //Metodo donde le pasamos el modelo
        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel clientemodel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido vamos a guardar los datos en la base
                    using(facturaEntities2 db = new facturaEntities2())
                    {
                        var oCliente = new cliente();
                        oCliente.id_cli = clientemodel.id_cli;
                        oCliente.nombre_cli = clientemodel.nombre_cli;
                        oCliente.cedula_cli = clientemodel.cedula_cli;
                        oCliente.correo_cli = clientemodel.correo_cli;
                        oCliente.fechaNacimiento_cli = clientemodel.fechaNacimiento_cli;

                        //Se añade y guradan los datos en la BDD
                        db.cliente.Add(oCliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index"); //redireccion
                }
                return View(clientemodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Metodo Editar

        public ActionResult Editar(int id)
        {
            ClienteViewModel model = new ClienteViewModel();

            using(facturaEntities2 db = new facturaEntities2())
            {
                var oCliente = db.cliente.Find(id);
                model.nombre_cli = oCliente.nombre_cli;
                model.cedula_cli = oCliente.cedula_cli;
                model.correo_cli = oCliente.correo_cli;
                model.fechaNacimiento_cli = (DateTime)oCliente.fechaNacimiento_cli;
                //Seteamos el id
                model.id_cli = oCliente.id_cli;

            }
            return View(model);
        }

        //Metodo donde le pasamos el modelo
        [HttpPost]
        public ActionResult Editar(ClienteViewModel clientemodel)
        {
            try
            {
                //Validar los data Annotations
                if (ModelState.IsValid)
                {
                    //Si todo es valido vamos a guardar los datos en la base
                    using (facturaEntities2 db = new facturaEntities2())
                    {
                        var oCliente = new cliente();
                        oCliente.id_cli = clientemodel.id_cli;
                        oCliente.nombre_cli = clientemodel.nombre_cli;
                        oCliente.cedula_cli = clientemodel.cedula_cli;
                        oCliente.correo_cli = clientemodel.correo_cli;
                        oCliente.fechaNacimiento_cli = clientemodel.fechaNacimiento_cli;

                        //Se añade y guradan los datos en la BDD
                        db.Entry(oCliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index"); //redireccion
                }
                return View(clientemodel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Metodo para Eliminar un cliente
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            //Conexión hacia la Bdd
            using(facturaEntities2 db = new facturaEntities2())
            {
                var oCliente = db.cliente.Find(id);
                db.cliente.Remove(oCliente);
                db.SaveChanges();
            }
            return Redirect("~/Cliente/");
        }
    }
}


