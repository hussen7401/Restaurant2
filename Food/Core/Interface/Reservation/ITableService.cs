using Core.Dtos.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interface.Reservation
{
    public interface ITableService
    {
        Task<ActionResult> GetTables();
        Task<ActionResult> GetTableById(int id);
        Task<ActionResult> CreateTable(TableDto tableDto);
        Task<ActionResult> UpdateTable(int id, TableDto tableDto);
        Task<ActionResult> DeleteTable(int id);
    }
}
