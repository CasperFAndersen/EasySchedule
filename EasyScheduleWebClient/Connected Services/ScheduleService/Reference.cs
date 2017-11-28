﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyScheduleWebClient.ScheduleService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ScheduleService.IScheduleService")]
    public interface IScheduleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/GetScheduleByCurrentDate", ReplyAction="http://tempuri.org/IScheduleService/GetScheduleByCurrentDateResponse")]
        Core.Schedule GetScheduleByCurrentDate(System.DateTime currentDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/GetScheduleByCurrentDate", ReplyAction="http://tempuri.org/IScheduleService/GetScheduleByCurrentDateResponse")]
        System.Threading.Tasks.Task<Core.Schedule> GetScheduleByCurrentDateAsync(System.DateTime currentDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/GetCurrentScheduleDepartmentId", ReplyAction="http://tempuri.org/IScheduleService/GetCurrentScheduleDepartmentIdResponse")]
        Core.Schedule GetCurrentScheduleDepartmentId(int depId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/GetCurrentScheduleDepartmentId", ReplyAction="http://tempuri.org/IScheduleService/GetCurrentScheduleDepartmentIdResponse")]
        System.Threading.Tasks.Task<Core.Schedule> GetCurrentScheduleDepartmentIdAsync(int depId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/InsertScheduleIntoDb", ReplyAction="http://tempuri.org/IScheduleService/InsertScheduleIntoDbResponse")]
        void InsertScheduleIntoDb(Core.Schedule schedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/InsertScheduleIntoDb", ReplyAction="http://tempuri.org/IScheduleService/InsertScheduleIntoDbResponse")]
        System.Threading.Tasks.Task InsertScheduleIntoDbAsync(Core.Schedule schedule);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/UpdateSchedule", ReplyAction="http://tempuri.org/IScheduleService/UpdateScheduleResponse")]
        void UpdateSchedule(Core.Schedule schedule, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IScheduleService/UpdateSchedule", ReplyAction="http://tempuri.org/IScheduleService/UpdateScheduleResponse")]
        System.Threading.Tasks.Task UpdateScheduleAsync(Core.Schedule schedule, int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IScheduleServiceChannel : EasyScheduleWebClient.ScheduleService.IScheduleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ScheduleServiceClient : System.ServiceModel.ClientBase<EasyScheduleWebClient.ScheduleService.IScheduleService>, EasyScheduleWebClient.ScheduleService.IScheduleService {
        
        public ScheduleServiceClient() {
        }
        
        public ScheduleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ScheduleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ScheduleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ScheduleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Core.Schedule GetScheduleByCurrentDate(System.DateTime currentDate) {
            return base.Channel.GetScheduleByCurrentDate(currentDate);
        }
        
        public System.Threading.Tasks.Task<Core.Schedule> GetScheduleByCurrentDateAsync(System.DateTime currentDate) {
            return base.Channel.GetScheduleByCurrentDateAsync(currentDate);
        }
        
        public Core.Schedule GetCurrentScheduleDepartmentId(int depId) {
            return base.Channel.GetCurrentScheduleDepartmentId(depId);
        }
        
        public System.Threading.Tasks.Task<Core.Schedule> GetCurrentScheduleDepartmentIdAsync(int depId) {
            return base.Channel.GetCurrentScheduleDepartmentIdAsync(depId);
        }
        
        public void InsertScheduleIntoDb(Core.Schedule schedule) {
            base.Channel.InsertScheduleIntoDb(schedule);
        }
        
        public System.Threading.Tasks.Task InsertScheduleIntoDbAsync(Core.Schedule schedule) {
            return base.Channel.InsertScheduleIntoDbAsync(schedule);
        }
        
        public void UpdateSchedule(Core.Schedule schedule, int id) {
            base.Channel.UpdateSchedule(schedule, id);
        }
        
        public System.Threading.Tasks.Task UpdateScheduleAsync(Core.Schedule schedule, int id) {
            return base.Channel.UpdateScheduleAsync(schedule, id);
        }
    }
}
