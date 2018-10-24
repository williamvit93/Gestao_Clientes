using Gestao_Clientes.Dados.Contexto;
using Gestao_Clientes.Dados.Interfaces;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Clientes.Dados.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private Gestao_ClientesContext _context;

        public UnitOfWork(Gestao_ClientesContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var erro = new StringBuilder();

                foreach (var eve in e.EntityValidationErrors)
                {
                    erro.AppendLine("Entidade do tipo " + eve.Entry.Entity.GetType().Name + " no estado " + eve.Entry.State + " tem os seguintes erros de validação:");

                    foreach (var ve in eve.ValidationErrors)
                    {
                        erro.AppendLine(" Property: " + ve.PropertyName + " Erro: " + ve.ErrorMessage);
                    }
                }

                var telemetriy = new TelemetryClient();
                telemetriy.TrackException(e.InnerException);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
