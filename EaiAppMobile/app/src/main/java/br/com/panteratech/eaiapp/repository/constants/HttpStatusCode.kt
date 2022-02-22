package br.com.panteratech.eaiapp.repository.constants

class HttpStatusCode {
    companion object {
        val OK = 200
        val CREATED = 201
        val NO_CONTENT = 204
        val BAD_REQUEST = 400
        val UNAUTHORIZED = 401
        val FORBIDEN  = 403
        val UNPROCESSABLE_ENTITY = 422
        val INTERNAL_ERROR = 500
        val BAD_GATEWAY = 503
    }
}