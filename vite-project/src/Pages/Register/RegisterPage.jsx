import React, { useState } from "react"
import { Input } from "../../Components/Input"
import { Button } from "../../Components/Button"
import { SmallText } from "../../Components/SmallText"
import CrossPNG from "../../Assets/cross.png"
const SITE_URL = import.meta.env.VITE_SITE_URL || ""
export const RegisterPage = () => {
	const [login, setLogin] = useState(null)
	const [password, setPassword] = useState(null)
	const handleRegisterButton = () => {
		axios
			.request({
				method: "POST",
				url: `${SITE_URL}/Auth/register`,
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
			})
			.catch((error) => {
				console.log(error)
			})
	}
	return (
		<div className='flex h-full'>
			<div className='w-1/3 h-full bg-registerBG bg-center bg-no-repeat bg-cover'></div>
			<div className='w-2/3 px-36 my-auto '>
				<div className='flex items-center justify-between mb-12'>
					<p className='font-medium text-pink text-4xl'>Регистрация</p>
					<a className='cursor-pointer'>
						<img src={CrossPNG} alt='exit' />
					</a>
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
						<Button title={"Зарегистрироваться"} onClick={handleRegisterButton} />
						<div className='flex w-full items-center justify-center gap-x-2 mt-4'>
							<SmallText text={"Уже есть аккаунт?"} />
							<a href='' className='underline text-[#AAABAD]'>
								Войти
							</a>
						</div>
					</div>
				</div>
			</div>
		</div>
	)
}
