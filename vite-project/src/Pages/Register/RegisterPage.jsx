import React, { useState } from "react"
import { Input } from "../../Components/Input"
import { Button } from "../../Components/Button"
import { SmallText } from "../../Components/SmallText"
import CrossPNG from "../../Assets/cross.png"
import axios from "axios"
import { Link, useNavigate } from "react-router-dom"
const SITE_URL = import.meta.env.VITE_SITE_URL || ""
export const RegisterPage = () => {
	const [message, setMessage] = useState(null)
	const [login, setLogin] = useState(null)
	const [password, setPassword] = useState(null)
	const navigate = useNavigate()
	const handleRegisterButton = () => {
		console.log("ckicl")
		axios
			.request({
				method: "POST",
				url: `${SITE_URL}/api/Auth/register`,
				headers: {
					"Content-Type": "application/json",
				},
				data: JSON.stringify({
					login: login,
					password: password,
				}),
			})
			.then((response) => {
				console.log(JSON.stringify(response.data))
				setMessage("Вы успешно зарегестрировались. Вас скоро перенаправят на вход")
				setTimeout(() => {
					navigate("/", { replace: true })
				}, 4000)
			})
			.catch((error) => {
				setMessage("Что-то пошло не так. Попробуйте позже.")
				console.log(error)
			})
	}
	return (
		<div className='flex h-full'>
			<div className='w-1/3 h-full bg-registerBG bg-center bg-no-repeat bg-cover'></div>
			<div className='w-2/3 px-36 my-auto '>
				{message && <p className='font-medium text-ourGrey text-4xl mb-4'>{message}</p>}
				<div className='flex items-center justify-between mb-12'>
					<p className='font-medium text-ourPink text-4xl'>Регистрация</p>
					<Link className='cursor-pointer' to='/'>
						<img src={CrossPNG} alt='exit' />
					</Link>
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
						<Button title={"Зарегистрироваться"} handlefunc={handleRegisterButton} />
						<div className='flex w-full items-center justify-center gap-x-2 mt-4'>
							<SmallText text={"Уже есть аккаунт?"} />
							<Link to='/' className='underline text-[#AAABAD]'>
								Войти
							</Link>
						</div>
					</div>
				</div>
			</div>
		</div>
	)
}
