import React from "react"
import Logo from "../Assets/Logo.png"
import { setPage } from "../redux/pageSlice"
import Profile from "../Assets/Profile.png"
import { useSelector, useDispatch } from "react-redux"
import { Link } from "react-router-dom"

export const Footer = () => {
	const pageName = useSelector((state) => state.page.page)
	const dispatch = useDispatch()
	return (
			<div className='w-full py-8 flex items-center justify-between max-w-7xl mx-auto '>
				<img src={Logo} alt='Logo' />
				<div className='items-center flex gap-x-8'>
					<Link
						to={"/team"}
						className={`font-sm block hover:text-ourPink ${pageName == "team" && "text-ourPink"}`}
						onClick={(e) => {
							dispatch(setPage("team"))
						}}
					>
						Найти команду
					</Link>
					<span className='w-1 h-6 bg-[#1D1F2426] ' />
					<Link
						to={"/people"}
						className={`font-sm block hover:text-ourOrange ${pageName == "member" && "text-ourOrange"}`}
						onClick={(e) => {
							dispatch(setPage("member"))
						}}
					>
						Найти участника
					</Link>
				</div>
				<Link
					to='/profile'
					onClick={(e) => {
						dispatch(setPage(null))
					}}
				>
					<img src={Profile} alt='' />
				</Link>
			</div>
	)
}
