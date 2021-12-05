using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QL_BanHang.Model;
using QL_BanHang.Obiect;

namespace QL_BanHang.Control
{
    class NhanVienCtr
    {
        NhanVienMod nvMod = new NhanVienMod();
        public DataTable GetData()
        {
            return nvMod.GetData();
        }
        public bool AddData(NhanVienObj nvObj)
        {
            return nvMod.AddData(nvObj);
        }
        public bool UpdData(NhanVienObj nvObj)
        {
            return nvMod.UpdData(nvObj);
        }
        public bool UpdMK(NhanVienObj nvObj)
        {
            return nvMod.UpdMK(nvObj);
        }
        public bool DelData(string ma)
        {
            return nvMod.DelData(ma);
        }

        /// <summary>
        /// Tìm kiếm nhân viên theo tên
        /// </summary>
        /// <param name="searchInput"></param>
        /// <returns></returns>
        public DataTable SearchEployee(string searchInput)
        {
            return nvMod.SearchEmployee(searchInput);
        }
    }
}
