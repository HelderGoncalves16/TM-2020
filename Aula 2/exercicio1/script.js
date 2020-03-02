function lerInput() {
    var texto = document.getElementById("numero").value;

    if(!texto.length ) alert("Sem Conteudo");

    document.getElementById("text").innerText = texto;
}