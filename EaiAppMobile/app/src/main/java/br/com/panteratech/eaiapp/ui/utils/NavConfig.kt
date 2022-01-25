package br.com.panteratech.eaiapp.ui.utils

import androidx.activity.viewModels
import androidx.compose.runtime.Composable
import androidx.hilt.navigation.compose.hiltViewModel
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import br.com.panteratech.eaiapp.ui.screens.login.LoginContainer
import br.com.panteratech.eaiapp.ui.screens.main.MainScreen
import br.com.panteratech.eaiapp.ui.screens.register.RegisterScreen
import br.com.panteratech.eaiapp.ui.screens.register.RegisterViewModel


@Composable
fun NavConfig() {
    val navController = rememberNavController()
    NavHost(
        navController = navController ,
        startDestination = "login"
    ) {
        composable("login") {
            LoginContainer(navController)
        }
        composable("register") {
            RegisterScreen()
        }
        composable("home"){
            MainScreen()
        }
    }
}
