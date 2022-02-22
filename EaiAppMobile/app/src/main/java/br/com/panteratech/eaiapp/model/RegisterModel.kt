package br.com.panteratech.eaiapp.model

data class RegisterModel(
    var urlImage: String = "",
    val username: String,
    val email: String,
    val password: String,
): BaseModel()
