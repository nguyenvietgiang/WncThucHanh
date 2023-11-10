document.getElementById("username").addEventListener("input", function () {
    var username = this.value;
    var errorSpan = document.getElementById("user-error");
    if (username.length === 0) { 
        errorSpan.textContent = "Username không được bỏ trống.";
    } else {
        errorSpan.textContent = ""; 
    }
});

document.getElementById("password").addEventListener("input", function () {
    var password = this.value;
    var errorSpan = document.getElementById("password-error");
    if (password.length < 8) {
        errorSpan.textContent = "Mật khẩu phải lớn hơn hoặc bằng 8 ký tự.";
    } else if (!/\d/.test(password)) {
        errorSpan.textContent = "Mật khẩu phải có ít nhất 1 số.";
    } else {
        errorSpan.textContent = "";
    }
});


document.getElementById("email").addEventListener("input", function () {
    var email = this.value;
    var errorSpan = document.getElementById("email-error");
    if (email.length === 0) { 
        errorSpan.textContent = "Email không được bỏ trống.";
    } else {
        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        if (!emailPattern.test(email)) {
            errorSpan.textContent = "Email không hợp lệ.";
        } else {
            errorSpan.textContent = "";
        }
    }
});