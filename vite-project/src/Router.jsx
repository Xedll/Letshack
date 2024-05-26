import { createBrowserRouter, RouterProvider } from "react-router-dom"
import { RegisterPage } from "./Pages/Register/RegisterPage"
import { LoginPage } from "./Pages/Login/LoginPage"
import { TeamSearch } from "./Pages/Search/TeamSearch"
import { PeopleSearch } from "./Pages/Search/PeopleSearch"
import { ProfilePage } from "./Pages/Profile/ProfilePage"

const router = createBrowserRouter([
	{
		path: "/register",
		element: <RegisterPage />,
	},
	{
		path: "/",
		element: <LoginPage />,
	},
	{
		path: "/team",
		element: <TeamSearch />,
	},
	{
		path: "/people",
		element: <PeopleSearch />,
	},
	{
		path: "/profile",
		element: <ProfilePage />,
	},
])
export const Router = () => {
	return <RouterProvider router={router} />
}
