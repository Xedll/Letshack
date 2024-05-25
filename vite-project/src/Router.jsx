import { createBrowserRouter, RouterProvider } from "react-router-dom"
import { RegisterPage } from "./Pages/Register/RegisterPage"
import { LoginPage } from "./Pages/Login/LoginPage"
import { TeamSearch } from "./Pages/Search/TeamSearch"

const router = createBrowserRouter([
	{
		path: "/register",
		element: <RegisterPage />,
	},
	{
		path: "/login",
		element: <LoginPage />,
	},
	{
		path: "/",
		element: <TeamSearch />,
	},
])
export const Router = () => {
	return <RouterProvider router={router} />
}
