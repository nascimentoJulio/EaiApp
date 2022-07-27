package br.com.panteratech.eaiapp.ui.components.shared.bottom_navigation

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.*
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.shadow
import androidx.compose.ui.graphics.Brush
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.painter.Painter
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import br.com.panteratech.eaiapp.R
import br.com.panteratech.eaiapp.ui.components.shared.default_text.DefaultText

@Composable
fun BottomNavigation(navController: NavController, actualRoute: String) {
    Row(
        horizontalArrangement = Arrangement.SpaceAround,
        verticalAlignment = Alignment.CenterVertically,
        modifier = Modifier
            .fillMaxWidth()
            .requiredHeight(75.dp)
            .background(MaterialTheme.colors.onPrimary)
    ) {
        ButtonNavItem(
            navController = navController,
            route = "profile",
            icon = painterResource(id = R.drawable.ic_person),
            actualRoute = actualRoute,
            name = "Perfil"
        )

        ButtonNavItem(
            navController = navController,
            route = "chats",
            icon = painterResource(id = R.drawable.ic_chat),
            actualRoute = actualRoute,
            name = "Chats"
        )

        ButtonNavItem(
            navController = navController,
            route = "add-friends",
            icon = painterResource(id = R.drawable.ic_person_add),
            actualRoute = actualRoute,
            name = "Adicionar"
        )
    }
}

@Composable
private fun ButtonNavItem(
    navController: NavController,
    name: String?,
    actualRoute: String,
    route: String,
    icon: Painter
) {
    if (route == actualRoute) {
        HighlightedButton {
            NavItem(icon = icon, name = null)
        }
    } else {
        Button(
            colors = ButtonDefaults.buttonColors(backgroundColor = Color.Transparent),
            elevation = ButtonDefaults.elevation(
                defaultElevation = 0.dp,
                pressedElevation = 0.dp,
                disabledElevation = 0.dp
            ),
            onClick = { navController.navigate(route) }
        ) {
            NavItem(name = name, icon = icon)
        }
    }
}

@Composable
private fun NavItem(name: String?, icon: Painter) {
    Column(
        verticalArrangement = Arrangement.Center,
        horizontalAlignment = Alignment.CenterHorizontally
    ) {
        if (name == null) {
            Icon(
                tint = Color.White,
                painter = icon,
                contentDescription = "icon"
            )
        }
        name?.let {
            Icon(
                tint = MaterialTheme.colors.primary,
                painter = icon,
                contentDescription = "icon"
            )
            DefaultText(text = it, color = MaterialTheme.colors.primary)
        }
    }
}


@Composable
private fun HighlightedButton(item: @Composable () -> Unit) {
    Button(
        modifier = Modifier
            .requiredSize(110.dp)
            .padding(5.dp)
            .offset(y = (-35).dp)
            .shadow(elevation = 0.dp),
        elevation = ButtonDefaults.elevation(
            defaultElevation = 0.dp,
            pressedElevation = 0.dp,
            disabledElevation = 0.dp
        ),
        shape = RoundedCornerShape(100),
        colors = ButtonDefaults.buttonColors(MaterialTheme.colors.background),
        onClick = {}
    ) {
        Button(
            modifier = Modifier.size(70.dp),
            onClick = { },
            colors = ButtonDefaults.buttonColors(MaterialTheme.colors.onSecondary),
            shape = RoundedCornerShape(100)
        ) {
            item()
        }
    }
}

