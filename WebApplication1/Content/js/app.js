const currentLocation = location.href;
var DsList = document.querySelector('#abc').querySelectorAll('.nav-link');
const menuLength = DsList.length;
for (let i = 0; i < menuLength; i++) {
    if (currentLocation == 'https://localhost:44377/SanPham/DanhSachSanPham' || currentLocation == 'https://localhost:44377/SanPham/SanPhamChiTiet' || currentLocation == 'https://localhost:44377/GioHang/ThanhToan'
        || currentLocation == 'https://localhost:44377/GioHang' || currentLocation == 'https://localhost:44377/GioHang/XacNhanDonHang') {
        document.getElementById('dmm').parentNode.parentNode.parentNode.classList.add("active");
    }
    else if (DsList[i].href === currentLocation) {
        DsList[i].parentNode.classList.add("active")
    }
}

