'use client'

import { Avatar, Button, NavbarItem, Popover, PopoverContent, PopoverTrigger } from "@nextui-org/react";
import { useSession } from 'next-auth/react'

export default function HeaderAuth() {
    const session = {
        status: "complete",
        data: {
            user: {
                name: "STOCK",
                image: ''
            }
        }
    }

    let authContent: React.ReactNode;

    if (session.status === 'loading') {
        authContent = null;

    } else if (session.data?.user) {
        authContent = <Popover placement="left">
            <PopoverTrigger>
                <Avatar src={session.data?.user.image || ''} />
            </PopoverTrigger>
            <PopoverContent>
                <div className='p-4'>
                    {/* //TODO: Create action for sign out */}
                    <form >
                        <Button type="submit">Sign Out</Button>
                    </form>
                </div>
            </PopoverContent>
        </Popover>
    } else {
        authContent = <>
            <NavbarItem>
                {/* TODO: Create sign In action for use in the form */}
                <form >

                    <Button type="submit" color="secondary" variant="bordered">
                        Sign In
                    </Button>
                </form>
            </NavbarItem>
            <NavbarItem>
                {/* // TODO: create sign Up action */}
                <form >
                    <Button type='submit' color='primary' variant='flat'>
                        Sign Up
                    </Button>
                </form>
            </NavbarItem>
        </>
    }

    return authContent
}