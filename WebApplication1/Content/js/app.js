const currentLocation = location.href;
console.log(currentLocation);
var DsList = document.querySelector('#abc').querySelectorAll('.nav-link');
console.log(document.getElementById('dmm').parentNode.parentNode.parentNode)
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

