using Gestao_Clientes.Dados.Interfaces;
using Gestao_Clientes.Dominio.Events;
using Gestao_Clientes.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Clientes.Negocios
{
    public class ApplicationService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        protected readonly IHandler<DomainNotification> Notifications;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (Notifications.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
