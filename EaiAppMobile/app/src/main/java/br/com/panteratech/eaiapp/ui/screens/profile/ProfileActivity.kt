package br.com.panteratech.eaiapp.ui.screens.profile

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Surface
import androidx.compose.material.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.navigation.NavController
import br.com.panteratech.eaiapp.ui.components.shared.bottom_navigation.BottomNavigation
import br.com.panteratech.eaiapp.ui.theme.EaiAppTheme

class ProfileActivity(private var navController: NavController) : ComponentActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        setContent {
            EaiAppTheme {
                Surface(color = MaterialTheme.colors.background) {

                    ProfileScreen(navController)
                }
            }
        }
    }
}

@Composable
fun ProfileScreen(navController: NavController) {
    Column(
        modifier = Modifier.fillMaxHeight(),
        verticalArrangement = Arrangement.SpaceBetween
    ) {
        Text(text = "Profile Screen")
        BottomNavigation(
            navController = navController,
            actualRoute = "profile"
        )
    }

}
