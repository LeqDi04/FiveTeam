// Lấy thẻ HTML có class là 'search-form' và lưu vào biến searchForm
let searchForm = document.querySelector('.search-form');
// Khi người dùng click vào phần tử có id là 'search-btn'
document.querySelector('#search-btn').onclick = () => {
    // Thêm hoặc loại bỏ class 'active' cho thẻ HTML đã lấy ở trên
    // Điều này sẽ kích hoạt hoặc vô hiệu hóa các hiệu ứng CSS được định nghĩa trong class 'active'
    searchForm.classList.toggle('active');

    // Loại bỏ class 'active' khỏi các phần tử khác nếu chúng có
    // Điều này đảm bảo rằng khi người dùng mở ô tìm kiếm, các phần tử khác sẽ đóng lại
    shoppingCart.classList.remove('active');
    loginForm.classList.remove('active');
    navBar.classList.remove('active');
}

let shoppingCart = document.querySelector('.shopping-cart');
document.querySelector('#cart-btn').onclick = () => {
    shoppingCart.classList.toggle('active');
    searchForm.classList.remove('active');
    loginForm.classList.remove('active');
    navBar.classList.remove('active');
}
// Lấy thẻ HTML có class là 'login-form' và lưu vào biến loginForm 
let loginForm = document.querySelector('.login-form');
// Khi người dùng click vào phần tử có id là 'search-btn'
document.querySelector('#login-btn').onclick = () => {
    loginForm.classList.toggle('active');
    searchForm.classList.remove('active');
    shoppingCart.classList.remove('active');
    navBar.classList.remove('active');
}
// Lấy thẻ HTML có class là 'navbar'' và lưu vào biến menu-btn 
let navBar = document.querySelector('.navbar');
// Khi người dùng click vào phần tử có id là 'search-btn'
document.querySelector('#menu-btn').onclick = () => {
    navBar.classList.toggle('active');
    searchForm.classList.remove('active');
    shoppingCart.classList.remove('active');
    loginForm.classList.remove('active');
}
// Thiết lập sự kiện cho việc cuộn trang web (scroll)
window.onscroll = () => {
  // Loại bỏ lớp 'active' khỏi phần tử có id 'searchForm' (dùng để ẩn form tìm kiếm)
  searchForm.classList.remove('active');
  
  // Loại bỏ lớp 'active' khỏi phần tử có id 'shoppingCart' (dùng để ẩn giỏ hàng)
  shoppingCart.classList.remove('active');
  
  // Loại bỏ lớp 'active' khỏi phần tử có id 'loginForm' (dùng để ẩn form đăng nhập)
  loginForm.classList.remove('active');
  
  // Loại bỏ lớp 'active' khỏi phần tử có id 'navBar' (dùng để ẩn thanh điều hướng)
  navBar.classList.remove('active');
}


// Khởi tạo một Swiper mới với selector ".product-slide"
var swiper = new Swiper(".product-slide", {
  // Lặp lại các slide
  loop: true,
  // Khoảng cách giữa các slide là 20px
  spaceBetween: 20,
  // Tự động chạy slideshow với độ trễ là 7500ms (7.5 giây)
  autoplay: {
      delay: 7500,
      // Tự động chạy slideshow không bị tắt khi người dùng tương tác với nó
      disableOnInteraction: false,
  },
  // Các slide được căn giữa
  centeredSlides: true,
  // Thiết lập số lượng slide hiển thị trên mỗi dòng dựa trên kích thước màn hình
  breakpoints: {
      // Khi độ rộng màn hình nhỏ hơn hoặc bằng 0px
      0: {
          // Hiển thị 1 slide trên mỗi dòng
          slidesPerView: 1,
      },
      // Khi độ rộng màn hình nhỏ hơn hoặc bằng 768px
      768: {
          // Hiển thị 2 slide trên mỗi dòng
          slidesPerView: 2,
      },
      // Khi độ rộng màn hình nhỏ hơn hoặc bằng 1020px
      1020: {
          // Hiển thị 3 slide trên mỗi dòng
          slidesPerView: 3,
      },
  },
});


 // Tạo một instance mới của Swiper với class "review-slider"
var swiper = new Swiper(".review-slider", {
  // Cho phép lặp lại các slide
  loop: true,
  // Khoảng cách giữa các slide
  spaceBetween: 20,
  // Tự động phát slide với thời gian chờ 7500ms (7.5 giây)
  autoplay: {
      delay: 7500,
      // Vô hiệu hóa autoplay khi người dùng tương tác với slider
      disableOnInteraction: false,
  },
  // Hiển thị slide trung tâm
  centeredSlides: true,
  // Thiết lập số lượng slide hiển thị trên mỗi viewport theo breakpoint
  breakpoints: {
      // breakpoint khi độ rộng viewport là 0px
      0: {
          slidesPerView: 1, // Hiển thị 1 slide trên mỗi lần trượt
      },
      // breakpoint khi độ rộng viewport là 768px
      768: {
          slidesPerView: 2, // Hiển thị 2 slide trên mỗi lần trượt
      },
      // breakpoint khi độ rộng viewport là 1020px
      1020: {
          slidesPerView: 3, // Hiển thị 3 slide trên mỗi lần trượt
      },
  },
});

