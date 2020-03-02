var arrayNumbers = [];

function adicionarNumero() {

    var numero = document.getElementById("numbersId").value;

    arrayNumbers.push(parseInt(numero));

    if(!numero.length) alert("Sem Conteudo")

    document.getElementById("text").innerText = arrayNumbers;

}

function calcularNumero(){

    if(arrayNumbers.length> 5) {
        var maiorNumero = Math.max.apply(Math, arrayNumbers);

        document.getElementById("resultado").innerText = maiorNumero;
    }
}