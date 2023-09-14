async function deposito() {
    let valorDeposito = $("#depositoValor").val();
    let response;

    await fetch(`/Home/Depositar?valor=${valorDeposito}`)
        .then(async (r) => response = await r.json())
        .then(console.log(response))

    location.reload(true)
}

async function saque() {
    let valorSaque = $("#saqueValor").val();
    let response;

    await fetch(`/Home/Saque?valor=${valorSaque}`)
        .then(async (r) => response = await r.json())

    console.log(response)

    location.reload(true)
}

async function emprestimo() {
    let valorEmprestimo = $("#emprestimoValor").val();
    let response;

    await fetch(`/Home/Emprestimo?valor=${valorEmprestimo}`)
        .then(async (r) => response = await r.json())

    console.log(response);

    location.reload(true);
}

async function pagarEmprestimo() {
    let valorEmprestimo = $("#emprestimoRestante").val();
    let response;

    await fetch(`/Home/PagarEmprestimo?valor=${valorEmprestimo.replace(",", ".")}`)
        .then(async (r) => response = await r.json())

    console.log(response);

    location.reload(true);
}