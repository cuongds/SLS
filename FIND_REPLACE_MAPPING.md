# 🔍 Complete Find & Replace Mapping Guide

## How to Use in VS Code

1. Open **Find & Replace**: `Ctrl+H`
2. For each table mapping below:
   - **Find**: `tbl_XXX` (old table name)
   - **Replace**: `new.Schema` (new schema name)
   - Click **Replace All**
3. Open the specified file first before doing Replace All

---

## ✅ ALREADY COMPLETED (Skip These)
- ✅ clsDauTu.cs → `core.Investment`
- ✅ clsThon.cs → `ref.Village`
- ✅ clsHoTro.cs → `core.Support`
- ✅ clsNhapMia.cs → `core.SugarCaneIntake`

---

## 📋 REMAINING 18 FILES - Find & Replace Mappings

### **PHASE 6 (Production Data) - HIGHEST PRIORITY**

**File: `Entities\clsLenhChatMia.cs`**
- Find: `tbl_LenhChatMia`
- Replace: `core.HarvestOrder`
- Count: ~8-10 occurrences

---

### **PHASE 5 (Financial & Payment Data)**

**File: `Entities\clsThanhToanMia.cs`**
- Find: `tbl_ThanhToanMia`
- Replace: `core.PaymentTransaction`
- Count: ~8-10 occurrences
- ⚠️ Note: Also has legacy query reference `MDSONLA.dbo.tbl_ThanhToanMia` (keep these as-is)

**File: `Entities\clsDotThanhToan.cs`**
- Find: `tbl_DotThanhToan`
- Replace: `core.PaymentBatch`
- Count: ~6-8 occurrences

**File: `Entities\clsBaiTapKet.cs`**
- Find: `tbl_BaiTapKet`
- Replace: `core.Settlement`
- Count: ~6-8 occurrences

---

### **PHASE 3 (Core Business Data)**

**File: `Entities\clsHopDong.cs`**
- Find: `tbl_HopDong`
- Replace: `core.Contract`
- Count: ~8-10 occurrences

**File: `Entities\clsThuaRuong.cs`**
- Find: `tbl_ThuaRuong`
- Replace: `core.Parcel`
- Count: ~8-10 occurrences

---

### **PHASE 2 (Security & Authentication)**

**File: `Entities\clsUser.cs`**
- Find: `tbl_NguoiDung`
- Replace: `auth.User`
- Count: ~6-8 occurrences

**File: `Entities\clsRoles.cs`**
- Find: `tbl_VaiTro`
- Replace: `auth.Roles`
- Count: ~6-8 occurrences

---

### **PHASE 1 (Reference Data)**

**File: `Entities\clsXa.cs`**
- Find: `tbl_Xa`
- Replace: `ref.Commune`
- Count: ~6-8 occurrences

**File: `Entities\clsHuyen.cs`** (if exists)
- Find: `tbl_Huyen`
- Replace: `ref.District`
- Count: ~6-8 occurrences

**File: `Entities\clsTinh.cs`** (if exists)
- Find: `tbl_Tinh`
- Replace: `ref.Province`
- Count: ~6-8 occurrences

---

### **PHASE 4 (Investment & Support)**

**File: `Entities\clsLoaiHinhDauTu.cs`**
- Find: `tbl_LoaiHinhDauTu`
- Replace: `ref.InvestmentType`
- Count: ~4-6 occurrences

**File: `Entities\clsDanhMucHoTro.cs`**
- Find: `tbl_DanhMucHoTro`
- Replace: `ref.SupportCategory`
- Count: ~4-6 occurrences

**File: `Entities\clsDanhMucDauTu.cs`** (if exists)
- Find: `tbl_DanhMucDauTu`
- Replace: `ref.InvestmentCategory` (or check mapping)
- Count: ~4-6 occurrences

---

## 🔧 STEP-BY-STEP INSTRUCTIONS

### Step 1: Open Find & Replace
```
Ctrl+H  (or View → Find and Replace)
```

### Step 2: For each file below, follow this pattern:

```
1. Open file in editor (Ctrl+O → type filename)
2. Open Find & Replace (Ctrl+H)
3. Paste "Find" text into Find box
4. Paste "Replace" text into Replace box
5. Click "Replace All" button
6. Save file (Ctrl+S)
7. Move to next file
```

### Step 3: Use Case-Sensitive Search (Optional but Recommended)
- Click the "Match Case" button (Aa icon) if needed to avoid matching partial words

---

## 📊 PRIORITY ORDER (Fastest to Slowest)

### **TIER 1: Highest Impact (Do First)**
1. clsLenhChatMia.cs → `core.HarvestOrder` (2.6M records)
2. clsThanhToanMia.cs → `core.PaymentTransaction` (500K+ records)
3. clsHopDong.cs → `core.Contract` (15K+ contracts)
4. clsThuaRuong.cs → `core.Parcel` (169K+ parcels)

### **TIER 2: High Impact**
5. clsDotThanhToan.cs → `core.PaymentBatch`
6. clsBaiTapKet.cs → `core.Settlement`
7. clsXa.cs → `ref.Commune`

### **TIER 3: Medium Impact**
8. clsUser.cs → `auth.User` (16K+ users)
9. clsRoles.cs → `auth.Roles`
10. clsLoaiHinhDauTu.cs → `ref.InvestmentType`
11. clsDanhMucHoTro.cs → `ref.SupportCategory`

### **TIER 4: Remaining**
12-18. Other reference entities

---

## ⚠️ SPECIAL CASES & NOTES

### Legacy Compatibility
- **clsThanhToanMia.cs**: Has legacy query `MDSONLA.dbo.tbl_ThanhToanMia` (keep these unchanged)
  - Only replace the first pattern matches within this file

### Check Before Replacing
- Some files might reference other tables (e.g., `tbl_HopDong` in child queries)
- This is intentional - replace all occurrences in each file

### Verification After Replace
After each Replace All:
- Check the "Replace" count shown (should match expected count)
- Scan through file with `Ctrl+F` for remaining old table names

---

## ✅ VERIFICATION CHECKLIST

After completing all replacements:

```
[ ] All 18 files updated
[ ] No more "tbl_*" table names in Entities folder
[ ] Build compiles: Ctrl+Shift+B
[ ] No red squiggles in Solution Explorer
[ ] Git shows all Entities\*.cs files modified
```

---

## 🚀 TOTAL TIME ESTIMATE

- **Per file**: 30-45 seconds (Find, Replace All, Save)
- **18 files**: ~9-13 minutes total
- **Build verification**: ~2-3 minutes

**Total: ~15 minutes to complete ALL remaining files**

---

## 💡 QUICK REFERENCE TABLE

| File | Find | Replace | Phase |
|------|------|---------|-------|
| clsLenhChatMia.cs | tbl_LenhChatMia | core.HarvestOrder | 6 |
| clsThanhToanMia.cs | tbl_ThanhToanMia | core.PaymentTransaction | 5 |
| clsDotThanhToan.cs | tbl_DotThanhToan | core.PaymentBatch | 5 |
| clsBaiTapKet.cs | tbl_BaiTapKet | core.Settlement | 5 |
| clsHopDong.cs | tbl_HopDong | core.Contract | 3 |
| clsThuaRuong.cs | tbl_ThuaRuong | core.Parcel | 3 |
| clsXa.cs | tbl_Xa | ref.Commune | 1 |
| clsUser.cs | tbl_NguoiDung | auth.User | 2 |
| clsRoles.cs | tbl_VaiTro | auth.Roles | 2 |
| clsLoaiHinhDauTu.cs | tbl_LoaiHinhDauTu | ref.InvestmentType | 4 |
| clsDanhMucHoTro.cs | tbl_DanhMucHoTro | ref.SupportCategory | 4 |

---

## 📝 EXECUTION LOG TEMPLATE

Copy this and fill in as you complete each file:

```
[ ] clsLenhChatMia.cs     - 8 replacements
[ ] clsThanhToanMia.cs    - 9 replacements (legacy queries kept)
[ ] clsDotThanhToan.cs    - 7 replacements
[ ] clsBaiTapKet.cs       - 7 replacements
[ ] clsHopDong.cs         - 9 replacements
[ ] clsThuaRuong.cs       - 9 replacements
[ ] clsXa.cs              - 7 replacements
[ ] clsUser.cs            - 6 replacements
[ ] clsRoles.cs           - 6 replacements
[ ] clsLoaiHinhDauTu.cs   - 5 replacements
[ ] clsDanhMucHoTro.cs    - 5 replacements

FINAL BUILD: [ ] Success / [ ] Failed
```

---

**Ready to start? Begin with clsLenhChatMia.cs (TIER 1) and work your way down!** 🚀
