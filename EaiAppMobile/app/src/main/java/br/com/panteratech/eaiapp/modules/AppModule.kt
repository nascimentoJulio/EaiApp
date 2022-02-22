package br.com.panteratech.eaiapp.modules

import android.content.Context
import br.com.panteratech.eaiapp.repository.remote.api.ChatRepository
import br.com.panteratech.eaiapp.repository.remote.api.EaiApi
import br.com.panteratech.eaiapp.repository.remote.api.LoginRepository
import br.com.panteratech.eaiapp.repository.remote.api.RegisterUserRepository
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.qualifiers.ApplicationContext
import dagger.hilt.components.SingletonComponent
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import javax.inject.Singleton

@Module
@InstallIn(SingletonComponent::class)
object AppModule {

    @Singleton
    @Provides
    fun createClient(): EaiApi {
        return Retrofit.Builder()
            .baseUrl("https://eai-app-back.herokuapp.com")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
            .create(EaiApi::class.java)
    }

    @Singleton
    @Provides
    fun createRepositoryChat(
        eaiApi: EaiApi,
    ): ChatRepository {
        return ChatRepository(eaiApi)
    }

    @Singleton
    @Provides
    fun createRepositoryRegisterUser(
        eaiApi: EaiApi,
        @ApplicationContext context: Context
    ): RegisterUserRepository {
        return RegisterUserRepository(eaiApi, context)
    }

    @Singleton
    @Provides
    fun createRepositoryLoginUser(
        eaiApi: EaiApi,
    ): LoginRepository {
        return LoginRepository(eaiApi)
    }


}