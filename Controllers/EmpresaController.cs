using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VIDEOTEC.Models;
using VIDEOTEC.Models.ViewModels;

namespace VIDEOTEC.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            List<ListEmpresaViewModel> lst;
            using (VIDEOTECEntities db = new VIDEOTECEntities())
            {
                lst = (from d in db.tbl_empresa
                       select new ListEmpresaViewModel
                       {
                           Emp_id_empresa = d.emp_id_empresa,
                           Emp_nombre = d.emp_nombre,
                           Emp_telefono = d.emp_telefono,
                           Emp_direccion = d.emp_direccion,
                           Emp_correo = d.emp_correo,
                           Emp_logo = d.emp_logo

                       }).ToList();


            }


            return View(lst);
        }
        //AGREGAR
        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VIDEOTECEntities db = new VIDEOTECEntities())

                    {
                        var oEmpresa = new tbl_empresa();
                        oEmpresa.emp_nombre = model.Emp_nombre;
                        oEmpresa.emp_telefono = model.Emp_telefono;
                        oEmpresa.emp_direccion = model.Emp_direccion;
                        oEmpresa.emp_correo = model.Emp_correo;
                        oEmpresa.emp_logo = model.Emp_logo;

                        db.tbl_empresa.Add(oEmpresa);
                        db.SaveChanges();
                    }

                    return Redirect("~/Empresa/");

                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }


        //EDITAR
        public ActionResult Editar(int Id)
        {
            EmpresaViewModel model = new EmpresaViewModel();
            using (VIDEOTECEntities db = new VIDEOTECEntities())
            {
                var oEmpresa = db.tbl_empresa.Find(Id);
                model.Emp_id_empresa = oEmpresa.emp_id_empresa;
                model.Emp_nombre = oEmpresa.emp_nombre;
                model.Emp_telefono = oEmpresa.emp_telefono;
                model.Emp_direccion = oEmpresa.emp_direccion;
                model.Emp_correo = oEmpresa.emp_correo;
                model.Emp_logo = oEmpresa.emp_logo;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EmpresaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (VIDEOTECEntities db = new VIDEOTECEntities())

                    {
                        var oEmpresa = db.tbl_empresa.Find(model.Emp_id_empresa);
                        oEmpresa.emp_nombre = model.Emp_nombre;
                        oEmpresa.emp_telefono = model.Emp_telefono;
                        oEmpresa.emp_direccion = model.Emp_direccion;
                        oEmpresa.emp_correo = model.Emp_correo;
                        oEmpresa.emp_logo = model.Emp_logo;

                        db.Entry(oEmpresa).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Empresa/");

                }
                return View(model);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }



        //ELIMINAR
        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
           
            using (VIDEOTECEntities db = new VIDEOTECEntities())
            {
                
                var oEmpresa = db.tbl_empresa.Find(Id);
                db.tbl_empresa.Remove(oEmpresa);
                db.SaveChanges();

            }

            return Redirect("~/Empresa/");
        }




    }
}
