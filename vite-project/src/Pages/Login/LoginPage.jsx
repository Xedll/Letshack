import React, { useState } from "react"
import { Input } from "../../Components/Input"
import { Button } from "../../Components/Button"
import CrossPNG from "../../Assets/cross.png"
import axios from "axios"
import { Link, useNavigate } from "react-router-dom"
import { useDispatch } from "react-redux"
import { setContacts, setDescription, setName, setSearching, setSkills } from "../../redux/profileSlice"

const SITE_URL = import.meta.env.VITE_SITE_URL || ""

export const LoginPage = () => {
	const [message, setMessage] = useState(null)
	const [login, setLogin] = useState(null)
	const [password, setPassword] = useState(null)
	const dispatch = useDispatch()
	const navigate = useNavigate()
	const handleLoginButton = () => {
		axios
			.request({
				method: "POST",
				url: `${SITE_URL}/api/Auth/login`,
				headers: {
					"Content-Type": "application/json",
				},
				data: JSON.stringify({
					login: login,
					password: password,
				}),
			})
			.then((response) => {
				const data = response.data
				console.log(data)
				dispatch(setName(data.initials))
				dispatch(setDescription(data.description))
				dispatch(setSkills(data.technologies))
				dispatch(setSearching(data.isVisible))
				dispatch(setContacts(data.tgId))
				localStorage.setItem("token", data.token)
				setTimeout(() => {
					localStorage.setItem("token", null)
					navigate("/", { replace: true })
					setMessage("Время сессии истекло. Войдите снова")
				}, 600000)
				navigate("/profile", { replace: true })
			})
			.catch((error) => {
				console.log(error)
				setMessage("Неверный логин или пароль, попробуйте ещё раз.")
			})
	}
	return (
		<div className='flex h-full'>
			<div className='w-1/3 h-full bg-registerBG bg-center bg-no-repeat bg-cover' />
			<div className='w-2/3 px-36 my-auto '>
				{message && <p className='font-medium text-ourGrey text-4xl mb-4'>{message}</p>}
				<div className='flex items-center justify-between mb-12'>
					<p className='font-medium text-ourPink text-4xl'>Вход</p>
				</div>
				<div className='flex flex-col gap-y-8'>
					<Input
						title={"Введите логин"}
						handlefunc={(e) => {
							setLogin(e.target.value)
						}}
					/>
					<Input
						title={"Введите пароль"}
						handlefunc={(e) => {
							setPassword(e.target.value)
						}}
					/>
					<div>
						<Button title={"Войти"} handlefunc={handleLoginButton} />
						<div className='flex w-full items-center justify-center gap-x-2 mt-4'>
							<Link to='/register' className='underline text-[#AAABAD]'>
								Зарегистрироваться
							</Link>
						</div>
					</div>
				</div>
			</div>
		</div>
	)
}
