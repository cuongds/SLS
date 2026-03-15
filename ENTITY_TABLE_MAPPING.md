# Entity Class to Database Table Mapping

## Project Migration Status
**Status:** In Progress  
**Date:** Current Session  
**Database Migration Reference:** DB_MIGRATION_MAPPING.md  
**Target Framework:** .NET Framework 4.0

---

## Summary of Table Migration Changes

### Completed ✅
- ✅ **clsDauTu.cs** → `tbl_DauTu` → `core.Investment`

### In Progress 🔄
- 🔄 Complete mapping of remaining 90+ entity classes
- 🔄 Identify all explicit table references
- 🔄 Update entities for migrated tables
- 🔄 Document unmigrated/legacy tables

### Pending 📋

#### High Priority (Phase 4-6 Tables)
- **clsHoTro.cs** → `tbl_HoTro` → `core.Support` (Phase 4)
- **clsLenhChatMia.cs** → `tbl_LenhChatMia` → `core.HarvestOrder` (Phase 6)
- **clsNhapMia.cs** → `tbl_NhapMia` → `core.SugarCaneIntake` (Phase 6)
- **clsBaiTapKet.cs** → `tbl_BaiTapKet` → `core.Settlement` (Phase 5)
- **clsDotThanhToan.cs** → `tbl_DotThanhToan` → `core.PaymentBatch` (Phase 5)
- **clsThanhToanMia.cs** → `tbl_ThanhToanMia` → `core.PaymentTransaction` (Phase 5)

#### Medium Priority (Phase 3 Tables)
- **clsHopDong.cs** → `tbl_HopDong` → `core.Contract` (Phase 3)
- **clsThuaRuong.cs** → `tbl_ThuaRuong` → `core.Parcel` (Phase 3)

#### Low Priority (Phase 1-2 Tables)
- **clsThon.cs** → `tbl_Thon` → `ref.Village` (Phase 1)
- **clsXa.cs** → `tbl_Xa` → `ref.Commune` (Phase 1)
- **clsLoaiHinhDauTu.cs** → `tbl_LoaiHinhDauTu` → `ref.InvestmentType` (Phase 4)
- **clsDanhMucHoTro.cs** → `tbl_DanhMucHoTro` → `ref.SupportCategory` (Phase 4)
- **clsUser.cs** → `tbl_NguoiDung` → `auth.User` (Phase 2)
- **clsRoles.cs** → `tbl_VaiTro` → `auth.Roles` (Phase 2)

#### Legacy/Unmigrated Tables (Keep As-Is)
- **clsKeHoachUngTienMat.cs** → `core.CashAdvance` (Custom mapping, not in migration doc)
- **Other legacy-only entities** → Keep existing table references

---

## Complete Entity Class List (90+ Classes)

### Core Business Entities (Phase 3)
| Class Name | Legacy Table | New Table | Migration Phase |
|---|---|---|---|
| clsHopDong | tbl_HopDong | core.Contract | 3 |
| clsThuaRuong | tbl_ThuaRuong | core.Parcel | 3 |

### Investment & Support (Phase 4)
| Class Name | Legacy Table | New Table | Migration Phase |
|---|---|---|---|
| clsDauTu | tbl_DauTu | core.Investment | 4 |✅|
| clsHoTro | tbl_HoTro | core.Support | 4 |
| clsLoaiHinhDauTu | tbl_LoaiHinhDauTu | ref.InvestmentType | 4 |
| clsDanhMucHoTro | tbl_DanhMucHoTro | ref.SupportCategory | 4 |
| clsDanhMucDauTu | tbl_DanhMucDauTu | (Not explicitly mapped - likely ref.InvestmentCategory) | 4 |

### Financial & Payment (Phase 5)
| Class Name | Legacy Table | New Table | Migration Phase |
|---|---|---|---|
| clsDotThanhToan | tbl_DotThanhToan | core.PaymentBatch | 5 |
| clsThanhToanMia | tbl_ThanhToanMia | core.PaymentTransaction | 5 |
| clsBaiTapKet | tbl_BaiTapKet | core.Settlement | 5 |

### Production (Phase 6)
| Class Name | Legacy Table | New Table | Migration Phase |
|---|---|---|---|
| clsNhapMia | tbl_NhapMia | core.SugarCaneIntake | 6 |
| clsLenhChatMia | tbl_LenhChatMia | core.HarvestOrder | 6 |

### Reference Data (Phase 1-2)
| Class Name | Legacy Table | New Table | Migration Phase |
|---|---|---|---|
| clsThon | tbl_Thon | ref.Village | 1 |
| clsXa | tbl_Xa | ref.Commune | 1 |
| clsUser | tbl_NguoiDung | auth.User | 2 |
| clsRoles | tbl_VaiTro | auth.Roles | 2 |
| clsHuyen | tbl_Huyen | ref.District | 1 |
| clsTinh | tbl_Tinh | ref.Province | 1 |

### Other Reference Data
| Class Name | Likely Legacy Table | Status |
|---|---|---|
| clsCum | tbl_Cum | TBD |
| clsRaiVu | tbl_RaiVu | TBD |
| clsVuTrong | tbl_VuTrong | TBD |
| clsKieuTrong | tbl_KieuTrong | TBD |
| clsGiongMia | tbl_GiongMia | TBD |
| clsLoaiDat | tbl_LoaiDat | TBD |
| clsMucDichTrong | tbl_MucDichTrong | TBD |
| clsTramNongVu | tbl_TramNongVu | TBD |

### Unmigrated/Legacy Tables (Keep Unchanged)
| Class Name | Legacy Table | Purpose | Reason |
|---|---|---|---|
| clsKeHoachUngTienMat | tbl_KeHoachUngTienMat | Cash advances | Not in migration mapping |
| clsKeHoachUngVanChuyen | tbl_KeHoachUngVanChuyen | Van chuyen planning | TBD |
| clsUngVatTuVanChuyen | tbl_UngVatTuVanChuyen | Material transport advances | TBD |
| clsHoanUngVanChuyen | tbl_HoanUngVanChuyen | Transport fund repayment | TBD |
| Other legacy-only | Various | Mobile features, etc. | Mobile-specific (not yet migrated) |

### Helper/Utility Classes (No direct table mapping)
- clsComFunctions.cs
- clsImportDienTich.cs
- clsTemp_Import_Excel_KeHoachUngTienMat.cs
- clsTemp_Import_Excel_KeHoachUngVanChuyen.cs
- clsGetGiaNhapMia.cs
- clsNhapMia_Can.cs
- clsNhapMia_Can.cs

---

## Key Observations

### Migration Document Findings
1. **6 Migration Phases** - Each with specific tables migrated
2. **Total Records Migrated:** 6,206,222 records across all phases
3. **Soft Delete Pattern:** All new tables use `IsDeleted` flag
4. **Audit Columns:** All new tables have `CreatedAt`, `CreatedBy`, `UpdatedAt`, `UpdatedBy`
5. **Unmigrated Features:** Mobile-only features remain in MDSONLA database

### Entity Class Patterns
1. Most entities follow standard ORM pattern with Save(), Delete(), Load(), GetList()
2. Heavy use of OleDbConnection and OleDbTransaction
3. SQL statements built with string concatenation (security note: using DBModule.RefineString for SQL injection prevention)
4. Use of DBModule utility class for database operations

### Strategy for Updates
1. **Batch by Phase:** Update entities in migration phase order (1 → 6)
2. **High Priority First:** Investment and Payment entities (Phases 4-5) are heavily used
3. **Test As You Go:** Run build after each batch to catch issues
4. **Document Carefully:** Track which entities have been updated
5. **Legacy Compatibility:** Keep unmigrated tables unchanged per migration guide

---

## Update Order (Recommended)

### Phase 1: Reference Data (4 entities)
1. clsThon → ref.Village
2. clsXa → ref.Commune
3. clsHuyen → ref.District (if exists)
4. clsTinh → ref.Province (if exists)

### Phase 2: Security (2 entities)
1. clsUser → auth.User
2. clsRoles → auth.Roles

### Phase 3: Core Business (2 entities)
1. clsHopDong → core.Contract
2. clsThuaRuong → core.Parcel

### Phase 4: Investment & Support (4 entities)
1. clsLoaiHinhDauTu → ref.InvestmentType
2. clsDanhMucHoTro → ref.SupportCategory
3. clsHoTro → core.Support
4. (clsDauTu already updated ✅)

### Phase 5: Financial & Payment (3 entities)
1. clsDotThanhToan → core.PaymentBatch
2. clsThanhToanMia → core.PaymentTransaction
3. clsBaiTapKet → core.Settlement

### Phase 6: Production (2 entities)
1. clsNhapMia → core.SugarCaneIntake
2. clsLenhChatMia → core.HarvestOrder

---

## Notes for Implementation

### For Each Entity File Update:
1. Find all occurrences of `Select * from tbl_` 
2. Find all occurrences of `Insert Into tbl_`
3. Find all occurrences of `Update tbl_`
4. Find all occurrences of `Delete from tbl_`
5. Replace with new schema-prefixed table name
6. Test build compilation

### Example Pattern:
```csharp
// OLD
strSQL = "Select * from tbl_HopDong where ID=" + ID.ToString();

// NEW
strSQL = "Select * from core.Contract where ID=" + ID.ToString();
```

### Build Verification:
After updates, run: `dotnet build` or equivalent for .NET Framework 4.0 project

---

**Next Action:** Proceed with Phase 1 updates (Reference Data - Thon, Xa, etc.)
