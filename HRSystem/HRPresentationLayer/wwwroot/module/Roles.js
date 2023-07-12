

Edit = (id, name) => {
    document.getElementById("exampleModalLabel").innerHTML = "تعديل";
    document.getElementById("btnsave").value = "تعديل";
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;
}

Reset = () => {
    document.getElementById("exampleModalLabel").innerHTML = "إضافة";
    document.getElementById("btnsave").value = "حفظ";
    document.getElementById("roleId").value = "";
    document.getElementById("roleName").value = "";
}