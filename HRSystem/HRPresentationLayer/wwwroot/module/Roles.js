

Edit = (id, name) => {
    document.getElementById("btnsave").innerHTML = "تعديل";
    document.getElementById("btnsave").value = "تعديل";
    document.getElementById("roleId").value = id;
    document.getElementById("roleName").value = name;
}

Reset = () => {
    document.getElementById("btnsave").value = "حفظ";
    document.getElementById("roleId").value = "";
    document.getElementById("roleName").value = "";
}