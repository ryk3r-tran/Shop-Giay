const currentLocation = location.href;
var DsList = document.querySelectorAll('.nav-link')
//for (var i = 0; i < DsList.length; i++) {
//    hrefs.push(DsList[i].href);
//}

var length = hrefs.length
for (let i = 0; i < 4 ; i++) {
    if (currentLocation == 'https://localhost:44377/Admin/TatCaSanPham' || currentLocation == 'https://localhost:44377/Admin/ThemSanPham' || currentLocation == 'https://localhost:44377/Admin/TatCaTaiKhoan'
        || currentLocation == 'https://localhost:44377/Admin/ThemTaiKhoan') {
        console.log(document.getSelection)
        document.getSelection.parentNode.parentNode.parentNode.classList.remove('collapsed')
    }
    else  {
        DsList[i].classList.remove('collapsed')
    }
}


//for (let i = 0; i < length; i++) {
//    if (hrefs[i] == currentLocation) {
//        DsList[i].classList.remove('collapsed')
//    }
//}
