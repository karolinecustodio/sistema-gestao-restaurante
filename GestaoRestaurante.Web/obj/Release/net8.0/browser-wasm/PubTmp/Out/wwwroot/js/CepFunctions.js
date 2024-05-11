let timeoutId;

function BuscaCep() {
    if (timeoutId) {
        clearTimeout(timeoutId);
    }

    timeoutId = setTimeout(function () {
        let cep = document.getElementById('cep').value;

        // Verificar se o campo do CEP está vazio
        if (cep.trim() === "") {
            return; // Não faz nada se o campo estiver vazio
        }

        let url = "https://brasilapi.com.br/api/cep/v1/" + cep;
        let request = new XMLHttpRequest();

        request.open("GET", url);
        request.send();

        // tratar a resposta da requisição
        request.onload = function () {
            if (request.status == 200) {
                let endereco = JSON.parse(request.response);

                console.log('aq')
                console.log(endereco);
                document.getElementById("rua").value = endereco.street;
                document.getElementById("bairro").value = endereco.neighborhood;
                document.getElementById("cidade").value = endereco.city;
                document.getElementById("estado").value = endereco.state;

               DotNet.invokeMethodAsync('Endereco.razor', 'AtualizarEndereco', endereco.street, endereco.neighborhood, endereco.city, endereco.state);

                // Atualizar os dados do endereço no objeto C#
                //window.enderecoDotNet.invokeMethodAsync('AtualizarEndereco', endereco.street, endereco.neighborhood, endereco.city, endereco.state);
            }
            else if (request.status == 404) {
                alert("CEP inválido");
            }
            else {
                alert("Erro ao fazer a requisição");
            }
        }
    }, 500);
}

document.addEventListener("DOMContentLoaded", function () {
    let cep = document.getElementById("cep");
    cep.addEventListener("blur", BuscaCep);
});