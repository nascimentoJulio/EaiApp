package br.com.panteratech.eaiapp.listeners

interface ApiListener<T> {
    fun onSuccess(t: T) : T
    fun onSuccess(t: List<T>)
    fun onError(message: String)
}