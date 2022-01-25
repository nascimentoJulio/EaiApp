package br.com.panteratech.eaiapp.listeners

interface ApiListener<T> {
    fun onSuccess(t: T) : T
    fun onError(t: String)
}