using Dapper;
using SelfServices.Common.Entity;
using SelfServices.Common.Generic;
using SelfServices.Common.Interface.Repositry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace SelfServices.Repositry.Rep
{
    public class NotificationRepositry : IRepositry, INotificationRepositry
    {
        #region :: Procedure Name 

        private const string get_notifications = "GET_NOTIFICATION";
        private const string get_notification_by_id = "GET_NOTIFICATION_BY_ID";
        private const string add_new_notification = "ADD_NEW_NOTIFICATION";
        private const string update_notification = "UPDATE_NOTIFICATION";
        private const string get_number_of_notification_by_user_no = "GET_NUMBER_OF_NOTIFICATION_BY_USER_NO";

        #endregion

        #region :: Parampter Name 

        private const string USER_NO = "@P_USER_NO";
        private const string NOTIFICATION_ID = "@P_NOTIFICATION_ID";
        private const string IS_READ = "@P_IS_READ";

        #endregion

        private readonly IDapper Dapper;

        public NotificationRepositry(IDapper dapper)
        {
            Dapper = dapper;
        }

        public async Task<List<Notification>> GetNotifications(long userNo)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(USER_NO, userNo, DbType.Int64, ParameterDirection.Input);
            List<Notification> notifications = await Dapper.GetAll<Notification>(get_notifications, dbparams, commandType: CommandType.StoredProcedure);
            return notifications;
        }

        public async Task<Notification> GetNotificationById(int Id)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(NOTIFICATION_ID, Id, DbType.Int32, ParameterDirection.Input);
            Notification notification = await Dapper.Get<Notification>(get_notification_by_id, dbparams, commandType: CommandType.StoredProcedure);
            return notification;
        }

        public async Task<int> UpdateNotification(Notification notification)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(NOTIFICATION_ID, notification.NOTIFICATION_ID, DbType.Int32, ParameterDirection.Input);
            dbparams.Add(IS_READ, notification.IS_READ, DbType.Boolean, ParameterDirection.Input);
            int nResult = await Dapper.Update(update_notification, dbparams, commandType: CommandType.StoredProcedure);
            return nResult;
        }

        public async Task<int> GetNumberOfNotification(long userNo)
        {
            var dbparams = new DynamicParameters();
            dbparams.Add(USER_NO, userNo, DbType.Int64, ParameterDirection.Input);
            int numberOfNotification = await Dapper.Get<int>(get_number_of_notification_by_user_no, dbparams, commandType: CommandType.StoredProcedure);
            return numberOfNotification;
        }
    }
}
